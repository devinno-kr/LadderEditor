﻿using Devinno.Communications.Modbus;
using Devinno.Extensions;
using Devinno.Forms;
using Devinno.Forms.Controls;
using Devinno.Forms.Dialogs;
using Devinno.Forms.Icons;
using Devinno.Forms.Themes;
using Devinno.PLC.Ladder;
using Devinno.Tools;
using LadderEditor.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LM = LadderEditor.Tools.LangTool;

namespace LadderEditor.Forms
{
    public partial class FormCommunicationInput : DvForm
    {
        #region Member Variable
        LcModbusRtuSlave MDRS = new LcModbusRtuSlave();
        LcModbusRtuMaster MDRM = new LcModbusRtuMaster();
        LcModbusTcpSlave MDTS = new LcModbusTcpSlave();
        LcModbusTcpMaster MDTM = new LcModbusTcpMaster();
        LcMqtt MQTT = new LcMqtt();
        #endregion

        #region Constructor
        public FormCommunicationInput()
        {
            InitializeComponent();

            #region ComboBox
            var bauds = new int[] { 4800, 9600, 19200, 38400, 57600, 115200 };
            MDRM_inBaudrate.Items.AddRange(bauds.Select(x => new TextIcon { Text = x.ToString(), Tag = x }));
            MDRS_inBaudrate.Items.AddRange(bauds.Select(x => new TextIcon { Text = x.ToString(), Tag = x }));

            MDRS_inBaudrate.SelectedIndex = bauds.Length - 1;
            MDRM_inBaudrate.SelectedIndex = bauds.Length - 1;
            #endregion

            #region Buttons
            btnComms.SelectionMode = true;
            btnComms.Buttons.Add(new ButtonInfo("MDRS") { Checked = true, Text = "Modbus RTU\r\nSlave", Size = new SizeInfo(DvSizeMode.Percent, 20) });
            btnComms.Buttons.Add(new ButtonInfo("MDRM") { Checked = false, Text = "Modbus RTU\r\nMaster", Size = new SizeInfo(DvSizeMode.Percent, 20) });
            btnComms.Buttons.Add(new ButtonInfo("MDTS") { Checked = false, Text = "Modbus TCP\r\nSlave", Size = new SizeInfo(DvSizeMode.Percent, 20) });
            btnComms.Buttons.Add(new ButtonInfo("MDTM") { Checked = false, Text = "Modbus TCP\r\nMaster", Size = new SizeInfo(DvSizeMode.Percent, 20) });
            btnComms.Buttons.Add(new ButtonInfo("MQTT") { Checked = false, Text = "MQTT", Size = new SizeInfo(DvSizeMode.Percent, 20) });

            MDRM_btnBindAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MDRM_btnBindAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });

            MDRM_btnMonitorAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MDRM_btnMonitorAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });

            MDTM_btnBindAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MDTM_btnBindAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });

            MDTM_btnMonitorAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MDTM_btnMonitorAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });

            MQTT_btnPubAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MQTT_btnPubAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });

            MQTT_btnSubAR.Buttons.Add(new ButtonInfo("Add") { IconString = "fa-plus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            MQTT_btnSubAR.Buttons.Add(new ButtonInfo("Del") { IconString = "fa-minus", IconSize = 12, Size = new SizeInfo(DvSizeMode.Percent, 50) });
            #endregion

            #region DataGrid
            var fns = new ModbusFunction[] { ModbusFunction.BITREAD_F1, ModbusFunction.BITREAD_F2, ModbusFunction.WORDREAD_F3, ModbusFunction.WORDREAD_F4 }.Select(x => new TextIcon { Text = x.ToString().Replace("_", " [").Replace("BITREAD", "Bit Read").Replace("WORDREAD", "Word Read") + "]", Value = x }).ToList();
            var mods = new BindMode[] { BindMode.BitRead, BindMode.BitWrite, BindMode.WordRead, BindMode.WordWrite }.Select(x => new TextIcon { Text = x.ToString(), Value = x }).ToList();
            MDRM_dgMonitor.ColumnColor = MDRM_dgBind.ColumnColor = MDTM_dgMonitor.ColumnColor = MDTM_dgBind.ColumnColor = MQTT_dgPub.ColumnColor = MQTT_dgSub.ColumnColor = Color.FromArgb(30, 30, 30);

            MDRM_dgMonitor.SelectionMode = DvDataGridSelectionMode.Selector;
            MDRM_dgMonitor.Columns.Add(new DvDataGridEditNumberColumn<byte>(MDRM_dgMonitor) { Name = "Slave", HeaderText = LM.Slave, SizeMode = DvSizeMode.Percent, Width = 15 });
            MDRM_dgMonitor.Columns.Add(new DvDataGridComboBoxColumn(MDRM_dgMonitor) { Name = "Func", HeaderText = LM.FuncCode, SizeMode = DvSizeMode.Percent, Width = 40, Items = fns });
            MDRM_dgMonitor.Columns.Add(new DvDataGridColumn(MDRM_dgMonitor) { Name = "Address", HeaderText = LM.StartAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(AddressCell) });
            MDRM_dgMonitor.Columns.Add(new DvDataGridEditNumberColumn<int>(MDRM_dgMonitor) { Name = "Length", HeaderText = LM.Length, SizeMode = DvSizeMode.Percent, Width = 15 });

            MDRM_dgBind.SelectionMode = DvDataGridSelectionMode.Selector;
            MDRM_dgBind.Columns.Add(new DvDataGridEditNumberColumn<byte>(MDRM_dgBind) { Name = "Slave", HeaderText = LM.Slave, SizeMode = DvSizeMode.Percent, Width = 15 });
            MDRM_dgBind.Columns.Add(new DvDataGridComboBoxColumn(MDRM_dgBind) { Name = "Mode", HeaderText = LM.FuncCode, SizeMode = DvSizeMode.Percent, Width = 35, Items = mods });
            MDRM_dgBind.Columns.Add(new DvDataGridColumn(MDRM_dgBind) { Name = "Address", HeaderText = LM.StartAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(AddressCell) });
            MDRM_dgBind.Columns.Add(new DvDataGridColumn(MDRM_dgBind) { Name = "Bind", HeaderText = LM.Bind, SizeMode = DvSizeMode.Percent, Width = 20, CellType = typeof(DvDataGridEditTextCell) });

            MDTM_dgMonitor.SelectionMode = DvDataGridSelectionMode.Selector;
            MDTM_dgMonitor.Columns.Add(new DvDataGridEditNumberColumn<byte>(MDTM_dgMonitor) { Name = "Slave", HeaderText = LM.Slave, SizeMode = DvSizeMode.Percent, Width = 15 });
            MDTM_dgMonitor.Columns.Add(new DvDataGridComboBoxColumn(MDTM_dgMonitor) { Name = "Func", HeaderText = LM.FuncCode, SizeMode = DvSizeMode.Percent, Width = 40, Items = fns });
            MDTM_dgMonitor.Columns.Add(new DvDataGridColumn(MDTM_dgMonitor) { Name = "Address", HeaderText = LM.StartAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(AddressCell) });
            MDTM_dgMonitor.Columns.Add(new DvDataGridEditNumberColumn<int>(MDTM_dgMonitor) { Name = "Length", HeaderText = LM.Length, SizeMode = DvSizeMode.Percent, Width = 15 });

            MDTM_dgBind.SelectionMode = DvDataGridSelectionMode.Selector;
            MDTM_dgBind.Columns.Add(new DvDataGridEditNumberColumn<byte>(MDTM_dgBind) { Name = "Slave", HeaderText = LM.Slave, SizeMode = DvSizeMode.Percent, Width = 15 });
            MDTM_dgBind.Columns.Add(new DvDataGridComboBoxColumn(MDTM_dgBind) { Name = "Mode", HeaderText = LM.FuncCode, SizeMode = DvSizeMode.Percent, Width = 35, Items = mods });
            MDTM_dgBind.Columns.Add(new DvDataGridColumn(MDTM_dgBind) { Name = "Address", HeaderText = LM.StartAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(AddressCell) });
            MDTM_dgBind.Columns.Add(new DvDataGridColumn(MDTM_dgBind) { Name = "Bind", HeaderText = LM.Bind, SizeMode = DvSizeMode.Percent, Width = 20, CellType = typeof(DvDataGridEditTextCell) });

            MQTT_dgPub.SelectionMode = DvDataGridSelectionMode.Selector;
            MQTT_dgPub.Columns.Add(new DvDataGridColumn(MQTT_dgPub) { Name = "Topic", HeaderText = LM.Topic, SizeMode = DvSizeMode.Percent, Width = 70, CellType = typeof(DvDataGridEditTextCell) });
            MQTT_dgPub.Columns.Add(new DvDataGridColumn(MQTT_dgPub) { Name = "Address", HeaderText = LM.MemoryAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(DvDataGridEditTextCell) });

            MQTT_dgSub.SelectionMode = DvDataGridSelectionMode.Selector;
            MQTT_dgSub.Columns.Add(new DvDataGridColumn(MQTT_dgSub) { Name = "Topic", HeaderText = LM.Topic, SizeMode = DvSizeMode.Percent, Width = 70, CellType = typeof(DvDataGridEditTextCell) });
            MQTT_dgSub.Columns.Add(new DvDataGridColumn(MQTT_dgSub) { Name = "Address", HeaderText = LM.MemoryAddress, SizeMode = DvSizeMode.Percent, Width = 30, CellType = typeof(DvDataGridEditTextCell) });
            #endregion

            #region Event
            #region btnComms.ButtonClick
            btnComms.SelectedChanged += (o, s) =>
            {
                switch(s.Button.Name)
                {
                    case "MDRS": tab.SelectedTab = tpMDRS; break;
                    case "MDRM": tab.SelectedTab = tpMDRM; break;
                    case "MDTS": tab.SelectedTab = tpMDTS; break;
                    case "MDTM": tab.SelectedTab = tpMDTM; break;
                    case "MQTT": tab.SelectedTab = tpMQTT; break;
                }

                SetToggle();
            };
            #endregion
            #region btn[OK/Cancel].ButtonClick
            btnOK.ButtonClick += (o, s) =>
            {
                var ret = ValidCheck();
                if (ret.Count == 0) DialogResult = DialogResult.OK;
                else
                {
                    var sb = new StringBuilder();
                    foreach (var v in ret) sb.AppendLine(v);
                    Program.MessageBox.ShowMessageBoxOk(LM.InputError, sb.ToString());
                }
            };
            btnCancel.ButtonClick += (o, s) => DialogResult = DialogResult.Cancel;
            #endregion
            #region MDRS_lblArea[P/M/T/C/D/WP/WM].ButtonClick
            MDRS_lblAreaP.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaM.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaT.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaC.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaD.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaWP.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDRS_lblAreaWM.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + " " + LM.AreaStartAddress, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };
            #endregion
            #region MDTS_lblArea[P/M/T/C/D/WP/WM].ButtonClick
            MDTS_lblAreaP.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaM.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaT.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaC.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaD.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaWP.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };

            MDTS_lblAreaWM.ButtonClicked += (o, s) =>
            {
                var c = ((DvValueLabelText)o);
                var r = InputBaseAddress(c.Text.Split(' ').FirstOrDefault() + LM.Area, c.Text);
                if (r.HasValue) c.Value = ValueTool.GetHexString(r.Value);
            };
            #endregion
            #region MDRM_btnMonitorAR.ButtonClick
            MDRM_btnMonitorAR.ButtonClick += (o, s) =>
            {
                var v = MDRM;

                if (s.Button.Name == "Add")
                {
                    v.Monitors.Add(new ModbusMonitor());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MDRM_dgMonitor.Rows.Where(x => x.Selected).Select(x => x.Source as ModbusMonitor);
                    foreach (var itm in sels) v.Monitors.Remove(itm);
                }

                var vpos1 = MDRM_dgMonitor.VScrollPosition;
                MDRM_dgMonitor.SetDataSource<ModbusMonitor>(v.Monitors);
                MDRM_dgMonitor.VScrollPosition = vpos1;
                MDRM_dgMonitor.Invalidate();
            };
            #endregion
            #region MDRM_btnBindAR.ButtonClick
            MDRM_btnBindAR.ButtonClick += (o, s) =>
            {
                var v = MDRM;

                if (s.Button.Name == "Add")
                {
                    v.Binds.Add(new ModbusBind());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MDRM_dgBind.Rows.Where(x => x.Selected).Select(x => x.Source as ModbusBind);
                    foreach (var itm in sels) v.Binds.Remove(itm);
                }

                var vpos1 = MDRM_dgBind.VScrollPosition;
                MDRM_dgBind.SetDataSource<ModbusBind>(v.Binds);
                MDRM_dgBind.VScrollPosition = vpos1;
                MDRM_dgBind.Invalidate();
            };
            #endregion
            #region MDTM_btnMonitorAR.ButtonClick
            MDTM_btnMonitorAR.ButtonClick += (o, s) =>
            {
                var v = MDTM;

                if (s.Button.Name == "Add")
                {
                    v.Monitors.Add(new ModbusMonitor());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MDTM_dgMonitor.Rows.Where(x => x.Selected).Select(x => x.Source as ModbusMonitor);
                    foreach (var itm in sels) v.Monitors.Remove(itm);
                }

                var vpos1 = MDTM_dgMonitor.VScrollPosition;
                MDTM_dgMonitor.SetDataSource<ModbusMonitor>(v.Monitors);
                MDTM_dgMonitor.VScrollPosition = vpos1;
                MDTM_dgMonitor.Invalidate();
            };
            #endregion
            #region MDTM_MDTM_btnBindAR.ButtonClick
            MDTM_btnBindAR.ButtonClick += (o, s) =>
            {
                var v = MDTM;

                if (s.Button.Name == "Add")
                {
                    v.Binds.Add(new ModbusBind());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MDTM_dgBind.Rows.Where(x => x.Selected).Select(x => x.Source as ModbusBind);
                    foreach (var itm in sels) v.Binds.Remove(itm);
                }

                var vpos1 = MDTM_dgBind.VScrollPosition;
                MDTM_dgBind.SetDataSource<ModbusBind>(v.Binds);
                MDTM_dgBind.VScrollPosition = vpos1;
                MDTM_dgBind.Invalidate();
            };
            #endregion
            #region MQTT_btnSub[Add/Del].ButtonClick
            MQTT_btnSubAR.ButtonClick += (o, s) =>
            {
                var v = MQTT;

                if (s.Button.Name == "Add")
                {
                    v.Subs.Add(new MqttPubSub());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MQTT_dgSub.Rows.Where(x => x.Selected).Select(x => x.Source as MqttPubSub);
                    foreach (var itm in sels) v.Subs.Remove(itm);
                }

                var vpos1 = MQTT_dgSub.VScrollPosition;
                MQTT_dgSub.SetDataSource(v.Subs);
                MQTT_dgSub.VScrollPosition = vpos1;
                MQTT_dgSub.Invalidate();
            };
            #endregion
            #region MQTT_btnPub[Add/Del].ButtonClick
            MQTT_btnPubAR.ButtonClick += (o, s) =>
            {
                var v = MQTT;

                if (s.Button.Name == "Add")
                {
                    v.Pubs.Add(new MqttPubSub());
                }
                else if (s.Button.Name == "Del")
                {
                    var sels = MQTT_dgPub.Rows.Where(x => x.Selected).Select(x => x.Source as MqttPubSub);
                    foreach (var itm in sels) v.Pubs.Remove(itm);
                }

                var vpos1 = MQTT_dgPub.VScrollPosition;
                MQTT_dgPub.SetDataSource(v.Pubs);
                MQTT_dgPub.VScrollPosition = vpos1;
                MQTT_dgPub.Invalidate();
            };
            #endregion
            #endregion

            #region Form Props
            StartPosition = FormStartPosition.CenterParent;
            this.Icon = Tools.IconTool.GetIcon(new Devinno.Forms.Icons.DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

            #region Icon
            Icon = IconTool.GetIcon(new DvIcon(TitleIconString, Convert.ToInt32(TitleIconSize)), Program.ICO_WH, Program.ICO_WH, Color.White);
            #endregion

        }
        #endregion

        #region Method
        #region InputBaseAddress
        int? InputBaseAddress(string Title, string Text)
        {
            int n2 = 0;
            var str2 = Text;
            bool b = false;
            if (str2 != null)
            {
                var r = ValueTool.GetHexValue(str2);
                b = r.HasValue;
                if (r.HasValue) n2 = r.Value;
            }

            int? ret = null;
            var str = Program.InputBox.ShowString(Title, b ? "0x" + n2.ToString("X4") : null);
            if (str != null)
            {
                var r = ValueTool.GetHexValue(str);
                if (r.HasValue) ret = r.Value;
            }
            return ret;
        }
        #endregion
        #region SetToggle
        void SetToggle()
        {
            if (tab.SelectedTab == tpMDRS) pnlContent.Text = MDRS.Name;
            if (tab.SelectedTab == tpMDRM) pnlContent.Text = MDRM.Name;
            if (tab.SelectedTab == tpMDTS) pnlContent.Text = MDTS.Name;
            if (tab.SelectedTab == tpMDTM) pnlContent.Text = MDTM.Name;
            if (tab.SelectedTab == tpMQTT) pnlContent.Text = MQTT.Name;
        }
        #endregion
        #region SetUI
        void SetUI()
        {
            SetToggle();

            #region MDRS
            {
                var v = MDRS;

                MDRS_inPort.Value = v.Port;
                MDRS_inBaudrate.SelectedIndex = MDRS_inBaudrate.Items.Select(x => (int)x.Tag).ToList().IndexOf(v.Baudrate);
                //MDRS_inSlave.Value = Convert.ToByte(v.Slave & 0xFF);
                MDRS_lblAreaP.Value = ValueTool.GetHexString(v.P_BaseAddress);
                MDRS_lblAreaM.Value = ValueTool.GetHexString(v.M_BaseAddress);
                MDRS_lblAreaT.Value = ValueTool.GetHexString(v.T_BaseAddress);
                MDRS_lblAreaC.Value = ValueTool.GetHexString(v.C_BaseAddress);
                MDRS_lblAreaD.Value = ValueTool.GetHexString(v.D_BaseAddress);
                MDRS_lblAreaWP.Value = ValueTool.GetHexString(v.WP_BaseAddress);
                MDRS_lblAreaWM.Value = ValueTool.GetHexString(v.WM_BaseAddress);
            }
            #endregion
            #region MDRM
            {
                var v = MDRM;

                MDRM_inPort.Value = v.Port;
                MDRM_inBaudrate.SelectedIndex = MDRM_inBaudrate.Items.Select(x => (int)x.Tag).ToList().IndexOf(v.Baudrate);
                MDRM_inInterval.Value = v.Interval;
                MDRM_inTimeout.Value = v.Timeout;

                var vpos1 = MDRM_dgMonitor.VScrollPosition;
                MDRM_dgMonitor.SetDataSource<ModbusMonitor>(v.Monitors);
                MDRM_dgMonitor.VScrollPosition = vpos1;
                MDRM_dgMonitor.Invalidate();

                var vpos2 = MDRM_dgBind.VScrollPosition;
                MDRM_dgBind.SetDataSource<ModbusBind>(v.Binds);
                MDRM_dgBind.VScrollPosition = vpos2;
                MDRM_dgBind.Invalidate();
            }
            #endregion
            #region MDTS
            {
                var v = MDTS;

                //MDTS_inSlave.Value = Convert.ToByte(v.Slave & 0xFF);
                MDTS_lblAreaP.Value = ValueTool.GetHexString(v.P_BaseAddress);
                MDTS_lblAreaM.Value = ValueTool.GetHexString(v.M_BaseAddress);
                MDTS_lblAreaT.Value = ValueTool.GetHexString(v.T_BaseAddress);
                MDTS_lblAreaC.Value = ValueTool.GetHexString(v.C_BaseAddress);
                MDTS_lblAreaD.Value = ValueTool.GetHexString(v.D_BaseAddress);
                MDTS_lblAreaWP.Value = ValueTool.GetHexString(v.WP_BaseAddress);
                MDTS_lblAreaWM.Value = ValueTool.GetHexString(v.WM_BaseAddress);
            }
            #endregion
            #region MDTM
            {
                var v = MDTM;

                MDTM_inRemoteIP.Value = v.RemoteIP;
                MDTM_inInterval.Value = v.Interval;
                MDTM_inTimeout.Value = v.Timeout;

                var vpos1 = MDTM_dgMonitor.VScrollPosition;
                MDTM_dgMonitor.SetDataSource<ModbusMonitor>(v.Monitors);
                MDTM_dgMonitor.VScrollPosition = vpos1;
                MDTM_dgMonitor.Invalidate();

                var vpos2 = MDTM_dgBind.VScrollPosition;
                MDTM_dgBind.SetDataSource<ModbusBind>(v.Binds);
                MDTM_dgBind.VScrollPosition = vpos2;
                MDTM_dgBind.Invalidate();
            }
            #endregion
            #region MQTT
            {
                var v = MQTT;

                MQTT_inRemoteIP.Value = v.BrokerIP;

                var vpos1 = MQTT_dgPub.VScrollPosition;
                MQTT_dgPub.SetDataSource<MqttPubSub>(v.Pubs);
                MQTT_dgPub.VScrollPosition = vpos1;
                MQTT_dgPub.Invalidate();

                var vpos2 = MQTT_dgSub.VScrollPosition;
                MQTT_dgSub.SetDataSource<MqttPubSub>(v.Subs);
                MQTT_dgSub.VScrollPosition = vpos2;
                MQTT_dgSub.Invalidate();
            }
            #endregion
        }
        #endregion

        #region Commit
        void Commit()
        {
            #region MDRS
            if (tab.SelectedTab == tpMDRS)
            {
                MDRS.Port = MDRS_inPort.Value;
                MDRS.Baudrate = (int)MDRS_inBaudrate.Items[MDRS_inBaudrate.SelectedIndex].Tag;


                if (MDRS_lblAreaP.ButtonWidth.HasValue) MDRS.P_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaP.Value) ?? 0;
                if (MDRS_lblAreaM.ButtonWidth.HasValue) MDRS.M_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaM.Value) ?? 0;
                if (MDRS_lblAreaT.ButtonWidth.HasValue) MDRS.T_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaT.Value) ?? 0;
                if (MDRS_lblAreaC.ButtonWidth.HasValue) MDRS.C_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaC.Value) ?? 0;
                if (MDRS_lblAreaD.ButtonWidth.HasValue) MDRS.D_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaD.Value) ?? 0;
                if (MDRS_lblAreaWP.ButtonWidth.HasValue) MDRS.WP_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaWP.Value) ?? 0;
                if (MDRS_lblAreaWM.ButtonWidth.HasValue) MDRS.WM_BaseAddress = ValueTool.GetHexValue(MDRS_lblAreaWM.Value) ?? 0;
            }
            #endregion
            #region MDRM
            else if (tab.SelectedTab == tpMDRM)
            {
                MDRM.Port = MDRM_inPort.Value;
                MDRM.Baudrate = (int)MDRM_inBaudrate.Items[MDRM_inBaudrate.SelectedIndex].Tag;
                MDRM.Interval = MDRM_inInterval.Value ?? 0;
                MDRM.Timeout = MDRM_inTimeout.Value ?? 0;
            }
            #endregion
            #region MDTS
            else if (tab.SelectedTab == tpMDTS)
            {
                MDTS.LocalPort = MDTS_inLocalPort.Value ?? 502;

                if (MDTS_lblAreaP.ButtonWidth.HasValue) MDTS.P_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaP.Value) ?? 0;
                if (MDTS_lblAreaM.ButtonWidth.HasValue) MDTS.M_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaM.Value) ?? 0;
                if (MDTS_lblAreaT.ButtonWidth.HasValue) MDTS.T_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaT.Value) ?? 0;
                if (MDTS_lblAreaC.ButtonWidth.HasValue) MDTS.C_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaC.Value) ?? 0;
                if (MDTS_lblAreaD.ButtonWidth.HasValue) MDTS.D_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaD.Value) ?? 0;
                if (MDTS_lblAreaWP.ButtonWidth.HasValue) MDTS.WP_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaWP.Value) ?? 0;
                if (MDTS_lblAreaWM.ButtonWidth.HasValue) MDTS.WM_BaseAddress = ValueTool.GetHexValue(MDTS_lblAreaWM.Value) ?? 0;
            }
            #endregion
            #region MDTM
            if (tab.SelectedTab == tpMDTM)
            {
                MDTM.RemoteIP = MDTM_inRemoteIP.Value;
                MDTM.Interval = MDTM_inInterval.Value ?? 0;
                MDTM.Timeout = MDTM_inTimeout.Value ?? 0;
            }
            #endregion
            #region MQTT
            if (tab.SelectedTab == tpMQTT)
            {
                MQTT.BrokerIP = MQTT_inRemoteIP.Value;
            }
            #endregion
        }
        #endregion
        #region GetResult
        ILadderComm GetResult()
        {
            ILadderComm ret = null;

            try
            {
                if (ValidCheck().Count == 0)
                {
                    Commit();

                    if (tab.SelectedTab == tpMDRS) ret = MDRS;
                    else if (tab.SelectedTab == tpMDRM) ret = MDRM;
                    else if (tab.SelectedTab == tpMDTS) ret = MDTS;
                    else if (tab.SelectedTab == tpMDTM) ret = MDTM;
                    else if (tab.SelectedTab == tpMQTT) ret = MQTT;
                }
            }
            catch { }

            return ret;
        }
        #endregion
        #region ValidCheck
        List<string> ValidCheck()
        {
            var ret = new List<string>();

            if (tab.SelectedTab == tpMDRS)
            {
                var n = 0;
                var c1 = !string.IsNullOrWhiteSpace(MDRS_inPort.Value);
                var c2 = MDRS_inBaudrate.SelectedIndex >= 0;
                var c4 = ValueTool.GetHexValue(MDRS_lblAreaP.Value).HasValue;
                var c5 = ValueTool.GetHexValue(MDRS_lblAreaM.Value).HasValue;
                var c6 = ValueTool.GetHexValue(MDRS_lblAreaT.Value).HasValue;
                var c7 = ValueTool.GetHexValue(MDRS_lblAreaC.Value).HasValue;
                var c8 = ValueTool.GetHexValue(MDRS_lblAreaD.Value).HasValue;
                var c9 = ValueTool.GetHexValue(MDRS_lblAreaWP.Value).HasValue;
                var c10 = ValueTool.GetHexValue(MDRS_lblAreaWM.Value).HasValue;

                if (!c1) ret.Add(LM.CommErrorPort);
                if (!c2) ret.Add(LM.CommErrorBaudrate);
                if (!c4) ret.Add(LM.CommErrorAreaP);
                if (!c5) ret.Add(LM.CommErrorAreaM);
                if (!c6) ret.Add(LM.CommErrorAreaT);
                if (!c7) ret.Add(LM.CommErrorAreaC);
                if (!c8) ret.Add(LM.CommErrorAreaD);
                if (!c9) ret.Add(LM.CommErrorAreaWP);
                if (!c10) ret.Add(LM.CommErrorAreaWM);
            }
            else if (tab.SelectedTab == tpMDRM)
            {
                var c1 = !string.IsNullOrWhiteSpace(MDRM_inPort.Value);
                var c2 = MDRM_inBaudrate.SelectedIndex >= 0;
                var c3 = MDRM_inInterval.Value.HasValue && MDRM_inInterval.Value >= 0;
                var c4 = MDRM_inTimeout.Value.HasValue && MDRM_inTimeout.Value >= 0;

                if (!c1) ret.Add(LM.CommErrorPort);
                if (!c2) ret.Add(LM.CommErrorBaudrate);
                if (!c3) ret.Add(LM.CommErrorInterval);
                if (!c4) ret.Add(LM.CommErrorTimeout);
            }
            else if (tab.SelectedTab == tpMDTS)
            {
                var n = 0;
                var c2 = ValueTool.GetHexValue(MDTS_lblAreaP.Value).HasValue;
                var c3 = ValueTool.GetHexValue(MDTS_lblAreaM.Value).HasValue;
                var c4 = ValueTool.GetHexValue(MDTS_lblAreaT.Value).HasValue;
                var c5 = ValueTool.GetHexValue(MDTS_lblAreaC.Value).HasValue;
                var c6 = ValueTool.GetHexValue(MDTS_lblAreaD.Value).HasValue;
                var c7 = ValueTool.GetHexValue(MDTS_lblAreaWP.Value).HasValue;
                var c8 = ValueTool.GetHexValue(MDTS_lblAreaWM.Value).HasValue;

                if (!c2) ret.Add(LM.CommErrorAreaP);
                if (!c3) ret.Add(LM.CommErrorAreaM);
                if (!c4) ret.Add(LM.CommErrorAreaT);
                if (!c5) ret.Add(LM.CommErrorAreaC);
                if (!c6) ret.Add(LM.CommErrorAreaD);
                if (!c7) ret.Add(LM.CommErrorAreaWP);
                if (!c8) ret.Add(LM.CommErrorAreaWM);
            }
            else if (tab.SelectedTab == tpMDTM)
            {
                var c1 = NetworkTool.ValidIPv4(MDTM_inRemoteIP.Value);
                var c2 = MDTM_inInterval.Value.HasValue && MDTM_inInterval.Value >= 0;
                var c3 = MDTM_inTimeout.Value.HasValue && MDTM_inTimeout.Value >= 0;

                if (!c1) ret.Add(LM.CommErrorRemoteIP);
                if (!c2) ret.Add(LM.CommErrorInterval);
                if (!c3) ret.Add(LM.CommErrorTimeout);
            }
            else if (tab.SelectedTab == tpMQTT)
            {
                var c1 = NetworkTool.ValidIPv4(MQTT_inRemoteIP.Value);
                var c2 = MQTT.Subs.Where(x => string.IsNullOrWhiteSpace(x.Topic)).Count() == 0;
                var c3 = MQTT.Pubs.Where(x => string.IsNullOrWhiteSpace(x.Topic)).Count() == 0;

                if (!c1) ret.Add(LM.CommErrorRemoteIP);
                if (!c2) ret.Add(LM.CommErrorSub);
                if (!c3) ret.Add(LM.CommErrorPub);

            }

            return ret;
        }
        #endregion

        #region LangSet
        void LangSet()
        {
            Title = LM.CommunicationItem;
            dvPanel2.Text = LM.CommunicationType;
            btnOK.Text = LM.Ok;
            btnCancel.Text = LM.Cancel;

            dvLabel1.Text = LM.Property;
            MDRS_inPort.Title = LM.Port;
            MDRS_inBaudrate.Title = LM.Baudrate;
            dvLabel2.Text = LM.MemoryMap;
            MDRS_lblAreaP.Title = "P " + LM.AreaStartAddress;
            MDRS_lblAreaM.Title = "M " + LM.AreaStartAddress;
            MDRS_lblAreaT.Title = "T " + LM.AreaStartAddress;
            MDRS_lblAreaC.Title = "C " + LM.AreaStartAddress;
            MDRS_lblAreaD.Title = "D " + LM.AreaStartAddress;
            MDRS_lblAreaWP.Title = "WP " + LM.AreaStartAddress;
            MDRS_lblAreaWM.Title = "WM " + LM.AreaStartAddress;

            dvLabel4.Text = LM.Property;
            MDRM_inPort.Title = LM.Port;
            MDRM_inBaudrate.Title = LM.Baudrate;
            MDRM_inInterval.Title = LM.Interval;
            MDRM_inTimeout.Title = LM.Timeout;
            dvLabel3.Text = LM.Monitoring;
            MDRM_dgMonitor.Columns[0].HeaderText = LM.Slave;
            MDRM_dgMonitor.Columns[1].HeaderText = LM.FuncCode;
            MDRM_dgMonitor.Columns[2].HeaderText = LM.StartAddress;
            MDRM_dgMonitor.Columns[3].HeaderText = LM.Length;
            dvLabel5.Text = LM.MemoryBind;
            MDRM_dgBind.Columns[0].HeaderText = LM.Slave;
            MDRM_dgBind.Columns[1].HeaderText = LM.FuncCode;
            MDRM_dgBind.Columns[2].HeaderText = LM.StartAddress;
            MDRM_dgBind.Columns[3].HeaderText = LM.Bind;

            dvLabel7.Text = LM.Property;
            dvLabel6.Text = LM.MemoryMap;
            MDTS_inLocalPort.Title = LM.PortNo;
            MDTS_lblAreaP.Title = "P " + LM.AreaStartAddress;
            MDTS_lblAreaM.Title = "M " + LM.AreaStartAddress;
            MDTS_lblAreaT.Title = "T " + LM.AreaStartAddress;
            MDTS_lblAreaC.Title = "C " + LM.AreaStartAddress;
            MDTS_lblAreaD.Title = "D " + LM.AreaStartAddress;
            MDTS_lblAreaWP.Title = "WP " + LM.AreaStartAddress;
            MDTS_lblAreaWM.Title = "WM " + LM.AreaStartAddress;

            dvLabel10.Text = LM.Property;
            MDTM_inRemoteIP.Title = LM.RemoteIP;
            MDTM_inInterval.Title = LM.Interval;
            MDTM_inTimeout.Title = LM.Timeout;
            dvLabel9.Text = LM.Monitoring;
            MDTM_dgMonitor.Columns[0].HeaderText = LM.Slave;
            MDTM_dgMonitor.Columns[1].HeaderText = LM.FuncCode;
            MDTM_dgMonitor.Columns[2].HeaderText = LM.StartAddress;
            MDTM_dgMonitor.Columns[3].HeaderText = LM.Length;
            dvLabel15.Text = LM.MemoryBind;
            MDTM_dgBind.Columns[0].HeaderText = LM.Slave;
            MDTM_dgBind.Columns[1].HeaderText = LM.FuncCode;
            MDTM_dgBind.Columns[2].HeaderText = LM.StartAddress;
            MDTM_dgBind.Columns[3].HeaderText = LM.Bind;

            dvLabel13.Text = LM.Property;
            MQTT_inRemoteIP.Title = LM.RemoteIP;
            dvLabel12.Text = LM.Subscribe;
            MQTT_dgSub.Columns[0].HeaderText = LM.Topic;
            MQTT_dgSub.Columns[1].HeaderText = LM.MemoryAddress;
            dvLabel11.Text = LM.Publish;
            MQTT_dgPub.Columns[0].HeaderText = LM.Topic;
            MQTT_dgPub.Columns[1].HeaderText = LM.MemoryAddress;
        }
        #endregion

        #region ShowCommInputAdd
        public ILadderComm ShowCommInputAdd()
        {
            #region Set
            this.Title = this.Text = LM.CommunicationAdd;

            MDRS = new LcModbusRtuSlave();
            MDRM = new LcModbusRtuMaster();
            MDTS = new LcModbusTcpSlave();
            MDTM = new LcModbusTcpMaster();
            MQTT = new LcMqtt();

            SetUI();
            #endregion

            LangSet();

            ILadderComm ret = null;
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = GetResult();
            }
            return ret;
        }
        #endregion
        #region ShowCommInputModify
        public ILadderComm ShowCommInputModify(ILadderComm v)
        {
            #region Set
            this.Title = this.Text = LM.CommunicationModify;

            MDRS = new LcModbusRtuSlave();
            MDRM = new LcModbusRtuMaster();
            MDTS = new LcModbusTcpSlave();
            MDTM = new LcModbusTcpMaster();
            MQTT = new LcMqtt();

            #region MDRS
            if (v is LcModbusRtuSlave)
            {
                var vm = v as LcModbusRtuSlave;
                var tm = MDRS;

                tm.Port = vm.Port;
                tm.Baudrate = vm.Baudrate;

                tm.P_BaseAddress = vm.P_BaseAddress;
                tm.M_BaseAddress = vm.M_BaseAddress;
                tm.T_BaseAddress = vm.T_BaseAddress;
                tm.C_BaseAddress = vm.C_BaseAddress;
                tm.D_BaseAddress = vm.D_BaseAddress;
                tm.WP_BaseAddress = vm.WP_BaseAddress;
                tm.WM_BaseAddress = vm.WM_BaseAddress;

                tab.SelectedTab = tpMDRS;
            }
            #endregion
            #region MDRM
            else if (v is LcModbusRtuMaster)
            {
                var vm = v as LcModbusRtuMaster;
                var tm = MDRM;

                tm.Port = vm.Port;
                tm.Baudrate = vm.Baudrate;
                tm.Monitors = vm.Monitors.Select(x => new ModbusMonitor()
                {
                    Slave = x.Slave,
                    Address = x.Address,
                    Func = x.Func,
                    Length = x.Length
                }).ToList();

                tm.Binds = vm.Binds.Select(x => new ModbusBind()
                {
                    Slave = x.Slave,
                    Address = x.Address,
                    Mode = x.Mode,
                    Bind = x.Bind
                }).ToList();

                tab.SelectedTab = tpMDRM;
            }
            #endregion
            #region MDTS
            else if (v is LcModbusTcpSlave)
            {
                var vm = v as LcModbusTcpSlave;
                var tm = MDTS;

                tm.LocalPort = vm.LocalPort;

                tm.P_BaseAddress = vm.P_BaseAddress;
                tm.M_BaseAddress = vm.M_BaseAddress;
                tm.T_BaseAddress = vm.T_BaseAddress;
                tm.C_BaseAddress = vm.C_BaseAddress;
                tm.D_BaseAddress = vm.D_BaseAddress;
                tm.WP_BaseAddress = vm.WP_BaseAddress;
                tm.WM_BaseAddress = vm.WM_BaseAddress;

                tab.SelectedTab = tpMDTS;
            }
            #endregion
            #region MDTM
            else if (v is LcModbusTcpMaster)
            {
                var vm = v as LcModbusTcpMaster;
                var tm = MDTM;

                tm.RemoteIP = vm.RemoteIP;
                tm.Monitors = vm.Monitors.Select(x => new ModbusMonitor()
                {
                    Slave = x.Slave,
                    Address = x.Address,
                    Func = x.Func,
                    Length = x.Length
                }).ToList();

                tm.Binds = vm.Binds.Select(x => new ModbusBind()
                {
                    Slave = x.Slave,
                    Address = x.Address,
                    Mode = x.Mode,
                    Bind = x.Bind
                }).ToList();

                tab.SelectedTab = tpMDTM;
            }
            #endregion
            #region MQTT
            else if (v is LcMqtt)
            {
                var vm = v as LcMqtt;
                var tm = MQTT;

                tm.BrokerIP = vm.BrokerIP;

                tm.Pubs = vm.Pubs.Select(x => new MqttPubSub() { Address = x.Address, Topic = x.Topic }).ToList();
                tm.Subs = vm.Subs.Select(x => new MqttPubSub() { Address = x.Address, Topic = x.Topic }).ToList();

                tab.SelectedTab = tpMQTT;
            }
            #endregion

            SetUI();
            #endregion

            LangSet();

            ILadderComm ret = null;
            if (this.ShowDialog() == DialogResult.OK)
            {
                ret = GetResult();
            }
            return ret;
        }
        #endregion
        #endregion

    }

    #region class : AddressCell
    public class AddressCell : DvDataGridCell
    {
        #region Properties
        public bool ReadOnly { get; set; }
        #endregion

        #region Member Variable
        string sVal = "";
        object old;
        #endregion

        #region Constructor
        public AddressCell(DvDataGrid Grid, DvDataGridRow Row, DvDataGridColumn Column) : base(Grid, Row, Column)
        {
            sVal = Value.ToString();
        }
        #endregion

        #region Override
        #region CellDraw
        public override void CellDraw(Graphics g, DvTheme Theme, RectangleF CellBounds, DvDataGridCellDrawInfo Info)
        {
            var CellTextColor = this.CellTextColor ?? Grid.ForeColor;
            var CellBackColor = this.CellBackColor ?? Grid.GetRowColor(Theme);
            var SelectedCellBackColor = this.SelectedCellBackColor ?? Grid.GetSelectedRowColor(Theme);
            var BoxColor = (Row.Selected ? SelectedCellBackColor : CellBackColor).BrightnessTransmit(Theme.DataGridInputBright);

            var nc = Grid;
            var s = "";
            var Font = nc.Font;
            var val = Value;

            Theme.DrawBox(g, CellBounds, BoxColor, BoxColor.BrightnessTransmit(Theme.BorderBrightness), RoundType.Rect, BoxStyle.Fill);
            if (Value != null && Value is int)
            {
                var v = (int)Value;
                #region Value
                s = ValueTool.GetHexString(v);
                
                if (!string.IsNullOrWhiteSpace(s))
                {
                    Theme.DrawText(g, s, Font, CellTextColor, CellBounds);
                }
                #endregion
            }
            Info.Bevel = false;
            base.CellDraw(g, Theme, CellBounds, Info);
        }
        #endregion
        #region CellMouseDown
        DateTime downTime;
        Point downPoint;
        public override void CellMouseDown(RectangleF CellBounds, int x, int y)
        {
            if (CollisionTool.Check(CellBounds, x, y) && !ReadOnly)
            {
                downPoint = new Point(x, y);
                downTime = DateTime.Now;
            }
            base.CellMouseDown(CellBounds, x, y);
        }
        #endregion
        #region CellMouseUp
        public override void CellMouseUp(RectangleF CellBounds, int x, int y)
        {
            if (CollisionTool.Check(CellBounds, x, y) && !ReadOnly && MathTool.GetDistance(downPoint, new Point(x, y)) < 10)
            {
                #region Click
                var Wnd = Grid.FindForm() as DvForm;
                var Theme = Grid.GetTheme();

                var CellBackColor = this.CellBackColor ?? Grid.GetRowColor(Theme);
                var SelectedCellBackColor = this.SelectedCellBackColor ?? Grid.GetSelectedRowColor(Theme);
                var BoxColor = (Row.Selected ? SelectedCellBackColor : CellBackColor).BrightnessTransmit(Theme.DataGridInputBright);
                if (CollisionTool.Check(CellBounds, x, y))
                {
                    Wnd.Block = true;

                    var ret = ValueTool.GetHexValue(Program.InputBox.ShowString(Column.HeaderText, ValueTool.GetHexString((int?)Value ?? 0)) ?? "");
                    if (ret.HasValue && !((object)ret.Value).Equals(Value))
                    {
                        #region Set
                        var val = ret.Value;
                        var old = Value;
                        Value = val;
                        Grid.InvokeValueChanged(this, old, (object)(ret.Value));
                        #endregion
                    }

                    Wnd.Block = false;

                }
                #endregion
            }
            base.CellMouseUp(CellBounds, x, y);
        }
        #endregion
        #endregion

        #region Method
        #endregion
    }
    #endregion
}
