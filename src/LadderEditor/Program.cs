using Devinno.Forms.Dialogs;
using LadderEditor.Forms;
using LadderEditor.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor
{
    static class Program
    {
        #region Const
        public const int ICO_WH = 18;
        #endregion

        #region Properties
        public static FormMain MainForm { get; private set; }
        public static DeviceManager DevMgr { get; private set; }
        public static LibraryManager LibMgr { get; private set; }
        public static DvMessageBox MessageBox { get; private set; }
        public static DvInputBox InputBox { get; private set; }
        public static PrivateFontCollection Fonts { get; private set; }
        #endregion

        #region Interop
        [DllImport("gdi32.dll")]
        private static extern int AddFontResource(string fontFilePath);

        [DllImport("gdi32.dll")]
        static extern bool RemoveFontResource(string lpFileName);
        #endregion

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region Fonts 
            Fonts = new PrivateFontCollection();
            var ba = Properties.Resources.NanumGothic;
            IntPtr p = Marshal.AllocHGlobal(ba.Length);
            Marshal.Copy(ba, 0, p, ba.Length);
            Fonts.AddMemoryFont(p, ba.Length);
            Marshal.FreeHGlobal(p);
            /*
            var path = Path.Combine(Application.StartupPath, "NanumGothic.ttf");
            RemoveFontResource(path);
            File.WriteAllBytes(path, Properties.Resources.NanumGothic);
            AddFontResource(path);
            */
            #endregion
            #region Directory
            var pathLib = Path.Combine(Application.StartupPath, "LadderLibraries");
            if (!Directory.Exists(pathLib)) Directory.CreateDirectory(pathLib);
            #endregion
            #region Managers
            LibMgr = new LibraryManager();
            DevMgr = new DeviceManager();
            #endregion
            #region Forms
            InputBox = new DvInputBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            MessageBox = new DvMessageBox() { StartPosition = FormStartPosition.CenterParent, MinWidth = 250 };
            MainForm = new FormMain();
            #endregion

            Application.Run(MainForm);
        }

        #region Static Method
        public static Font CreateFont(float size) => new Font(Fonts.Families[0], size);
        #endregion
    }
}
