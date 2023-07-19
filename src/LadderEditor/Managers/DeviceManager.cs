using Devinno.Communications.TextComm.TCP;
using Devinno.Data;
using Devinno.PLC.Ladder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LM = LadderEditor.Tools.LangTool;
namespace LadderEditor.Managers
{
    public class DeviceManager
    {
        #region Properties
        public bool IsConnected => comm.IsStart && comm.IsOpen;
        public bool IsDebugging { get; private set; }
        public string TargetIP => comm.RemoteIP;

        private EngineState devstate = EngineState.DISCONNECTED;
        public EngineState DeviceState
        {
            get
            {
                var ret = EngineState.DISCONNECTED;
                if (IsConnected) ret = devstate;
                return ret;
            }
        }
        #endregion

        #region Member Variable
        private TextCommTCPMaster comm;
        #endregion

        #region Constructor
        public DeviceManager()
        {
            comm = new TextCommTCPMaster()
            {
                RemotePort = 25851,
                MessageEncoding = Encoding.UTF8,
                AutoStart = false,
                BufferSize = 8 * 1024 * 1024,
            };
            comm.MessageReceived += Comm_MessageReceived;
            comm.TimeoutReceived += Comm_TimeoutReceived;
            comm.Timeout = 1000;
            comm.Interval = 1;
            comm.AutoSend(LadderEngine.CMD_STATE, 1, LadderEngine.CMD_STATE, "");
        }
        #endregion

        #region Event
        private void Comm_TimeoutReceived(object sender, TextCommTCPMaster.TimeoutEventArgs e)
        {
            try
            {
                switch (e.MessageID)
                {
                    case LadderEngine.CMD_DOWNLOAD:
                        {
                            Program.MainForm.BeginInvoke(new Action(() => Program.MainForm.Message(LM.Download, LM.DownloadFail)));
                        }
                        break;
                    case LadderEngine.CMD_UPLOAD:
                        {
                            Program.MainForm.BeginInvoke(new Action(() => Program.MainForm.Message(LM.Upload, LM.UploadFail)));
                        }
                        break;
                }
            }
            catch { }
        }

        private void Comm_MessageReceived(object sender, TextCommTCPMaster.ReceivedEventArgs e)
        {
            try
            {
                switch (e.Command)
                {
                    case LadderEngine.CMD_DOWNLOAD:
                        {
                            var v = Serialize.JsonDeserialize<PacketResult>(e.Message);
                            Program.MainForm.BeginInvoke(new Action(() => Program.MainForm.Message(LM.Download, v.Message == "OK" ? LM.DownloadComplete : LM.DownloadFail)));
                        }
                        break;
                    case LadderEngine.CMD_UPLOAD:
                        {
                            var v = Serialize.JsonDeserialize<LadderDocument>(e.Message);
                            Program.MainForm.Invoke(new Action(() => Program.MainForm.UploadFile(v)));
                            Program.MainForm.BeginInvoke(new Action(() => Program.MainForm.Message(LM.Upload, LM.UploadComplete)));
                        }
                        break;
                    case LadderEngine.CMD_DEBUG:
                        {
                            var v = DebugInfo.FromPacketString(e.Message);
                            if (v != null)
                            {
                                Program.MainForm.Invoke(new Action(() => Program.MainForm.Debug(v)));
                            }
                        }
                        break;
                    case LadderEngine.CMD_STATE:
                        {
                            var v = Serialize.JsonDeserialize<PacketState>(e.Message);
                            if (v != null)
                            {
                                devstate = v.State;
                            }
                        }
                        break;
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Method
        #region Start
        public void Start(string IP)
        {
            Stop();

            comm.RemoteIP = IP;
            comm.Start();
        }
        #endregion
        #region Stop
        public void Stop()
        {
            comm.Stop();
            IsDebugging = false;
        }
        #endregion
        #region Download
        public void Download(LadderDocument doc)
        {
            if (IsConnected && doc != null)
            {
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

                comm.ManualSend(LadderEngine.CMD_DOWNLOAD, 1, LadderEngine.CMD_DOWNLOAD, s);
            }
        }
        #endregion
        #region Upload
        public void Upload()
        {
            if (IsConnected)
            {
                comm.ManualSend(LadderEngine.CMD_UPLOAD, 1, LadderEngine.CMD_UPLOAD, "");
            }
        }
        #endregion
        
        #region StartDebug
        public void StartDebug()
        {
            if (IsConnected)
            {
                IsDebugging = true;
                comm.AutoSend(LadderEngine.CMD_DEBUG, 1, LadderEngine.CMD_DEBUG, "");
            }
        }
        #endregion
        #region StopDebug
        public void StopDebug()
        {
            if (IsConnected)
            {
                IsDebugging = false;
                comm.RemoveAuto(LadderEngine.CMD_DEBUG);
            }
        }
        #endregion
        #endregion
    }

    #region class : DMSG
    class DMSG
    {
        public string Lib { get; set; }
        public string Doc { get; set; }
    }
    #endregion
}
