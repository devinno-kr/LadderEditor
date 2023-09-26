using Devinno.Forms.Dialogs;
using Devinno.Tools;
using Devinno.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devinno.Data;
using System.IO;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using Devinno.Communications.TextComm.TCP;
using Devinno.PLC.Ladder;
using LadderEditor.Managers;

namespace LadderEditor.Forms
{
    public partial class FormMultiDownload : DvForm
    {
        #region Member Variable
        DvKeypad Keypad = new DvKeypad() { BlankForm = true, FormBorderStyle = FormBorderStyle.FixedSingle };
        FormMDDev DevInputBox = new FormMDDev();
        List<DownData> devs = new List<DownData>();
        Timer tmr = new Timer();
        #endregion

        #region Constructor
        public FormMultiDownload()
        {
            InitializeComponent();

            Theme.TouchMode = true;

            #region dg
            dg.SelectionMode = DvDataGridSelectionMode.Selector;
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "IP", HeaderText = "아이피", SizeMode = Devinno.Forms.DvSizeMode.Percent, Width = 50 });
            dg.Columns.Add(new DvDataGridColumn(dg) { Name = "StatusText", HeaderText = "상태", SizeMode = Devinno.Forms.DvSizeMode.Percent, Width = 50 });
            dg.CellMouseClick += (o, s) =>
            {
                if (s.Cell.Column.Name == "IP" && btnDownload.Enabled)
                {
                    var v = s.Cell.Row.Source as DownData;
                    var ip = v?.IP ?? NetworkTool.GetLocalIP();
                    var cls = ip.Split('.');
                    byte a, b, c, d;
                    byte? ret = null;
                    if (cls.Length == 4 && byte.TryParse(cls[0], out a) && byte.TryParse(cls[1], out b) && byte.TryParse(cls[2], out c) && byte.TryParse(cls[3], out d))
                    {
                        ret = Keypad.ShowKeypad<byte>("D Class", d, 1, 254);
                        if(ret.HasValue)
                        {
                            v.IP = $"{a}.{b}.{c}.{ret.Value}";
                            Serialize.JsonSerializeToFile("multi.json", devs);
                        }
                    }
                }
            };
            #endregion
            #region Load
            if (File.Exists("multi.json"))
            {
                devs = Serialize.JsonDeserializeFromFile<List<DownData>>("multi.json");
                dg.SetDataSource<DownData>(devs);
            }
            #endregion
            #region Timer
            tmr.Interval = 10;
            tmr.Tick += (o, s) => dg.Invalidate();
            tmr.Enabled = true;
            #endregion
            #region btnDevInput.ButtonClick
            btnDevInput.ButtonClick += (o, s) =>
            {
                var ret = DevInputBox.ShowDevInput();
                if (ret != null)
                {
                    int n = 0;
                    var ls = ret.Replace("//", "").Split("\r\n").Where(x => int.TryParse(x.Split(' ').LastOrDefault(), out n) && n != 0).Select(x => n);
                    var ip = NetworkTool.GetLocalIP();

                    var cls = ip.Split('.');
                    byte a, b, c;

                    if (cls.Length == 4 && byte.TryParse(cls[0], out a) && byte.TryParse(cls[1], out b) && byte.TryParse(cls[2], out c))
                    {
                        devs.Clear();
                        devs.AddRange(ls.Select(d => new DownData { IP = $"{a}.{b}.{c}.{d}" }));
                        dg.SetDataSource<DownData>(devs);
                        Serialize.JsonSerializeToFile("multi.json", devs);
                    }
                }
            };
            #endregion
            #region btnDownload.ButtonClick
            btnDownload.ButtonClick += (o, s) =>
            {
                if (Program.MainForm.CurrentDocument != null)
                {
                    btnDownload.Enabled = false;
                    var vls = dg.Rows.Where(x => x.Selected).Select(x => x.Source as DownData).ToList();

                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        if (vls.Count > 0)
                        {
                            foreach (var v in vls) v.Start();

                            #region doc
                            var doc = Program.MainForm.CurrentDocument;
                            var lk = doc.Libraries.ToLookup(x => x.DllPath);
                            var ls = new List<LadderDll>();
                            foreach (var v in lk)
                            {
                                var dll = Program.LibMgr.References.Where(x => x.DllPath == v.Key).FirstOrDefault();
                                if (dll != null) ls.Add(dll);
                            }
                            var sLib = Serialize.JsonSerialize(ls);
                            var sDoc = Serialize.JsonSerialize(doc);
                            var s = Serialize.JsonSerialize(new DMSG { Doc = sDoc, Lib = sLib });
                            #endregion

                            foreach (var v in vls) v.Download(s);

                            Thread.Sleep(3000);
                            this.Invoke(new Action(() =>
                            {
                                while (vls.Where(x => !x.Complete).Count() > 0 && this.Visible) 
                                    Thread.Sleep(100);
                            }));
                         
                            foreach (var v in devs) v.Stop();
                        }
                        this.Invoke(new Action(() => { btnDownload.Enabled = true; }));
                    });
                }
                else Program.MessageBox.ShowMessageBoxOk("다운로드", "문서가 열려있지 않습니다.");
            };
            #endregion
        }
        #endregion

        #region Method
        internal void ShowMultiDownload()
        {
            this.ShowDialog();
        }
        #endregion
    }

    public class DownData
    {
        #region Properties
        public string IP { get; set; } = null;
        public string StatusText => Status.ToString();
        public EngineState Status { get; private set; } = EngineState.DISCONNECTED;
        public bool Complete { get; private set; } = false;
        #endregion

        #region Member Variable
        private TextCommTCPMaster comm;
        #endregion

        #region Constructor
        public DownData()
        {
            #region Comm
            comm = new TextCommTCPMaster
            {
                RemotePort = 25851,
                MessageEncoding = Encoding.UTF8,
                AutoStart = false,
                BufferSize = 8 * 1024 * 1024,
            };

            comm.MessageReceived += (o, e) =>
            {
                try
                {
                    switch (e.Command)
                    {
                        case LadderEngine.CMD_DOWNLOAD:
                            {
                                var v = Serialize.JsonDeserialize<PacketResult>(e.Message);
                                ThreadPool.QueueUserWorkItem((o) => { Thread.Sleep(5000); Complete = true; });
                            }
                            break;
                        case LadderEngine.CMD_STATE:
                            {
                                var v = Serialize.JsonDeserialize<PacketState>(e.Message);
                                if (v != null)
                                {
                                    Status = v.State;
                                }
                            }
                            break;
                    }
                }
                catch (Exception ex) { }
            };
            #endregion
        }
        #endregion

        #region Method
        #region Start
        public void Start()
        {
            comm.RemoteIP = IP;
            Complete = false;
            comm.Start();
            comm.AutoSend(LadderEngine.CMD_STATE, 1, LadderEngine.CMD_STATE, "");
        }
        #endregion
        #region Stop
        public void Stop()
        {
            comm.Stop();
            comm.ClearAuto();
            //Status = EngineState.DISCONNECTED;
        }
        #endregion
        #region Download
        public void Download(string s)
        {
            if (comm.IsStart && comm.IsOpen && s != null)
            {
                comm.ManualSend(LadderEngine.CMD_DOWNLOAD, 1, LadderEngine.CMD_DOWNLOAD, s);
            }
        }
        #endregion
        #endregion
    }

}
