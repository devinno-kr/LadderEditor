using Devinno.Data;
using Devinno.PLC.Ladder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LadderEditor.Datas
{
    public class EditorLadderDocument : LadderDocument
    {
        #region Properties
        [Newtonsoft.Json.JsonIgnore]
        public string FileName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public bool Edit { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string DisplayTitle => (string.IsNullOrWhiteSpace(Title) ? "NONAME" : Title) + (MustSave ? "*" : "");
        [Newtonsoft.Json.JsonIgnore]
        public bool MustSave => Edit || string.IsNullOrWhiteSpace(FileName);


        #endregion

        #region Method
        #region Save(path)
        void Save(string path) => Serialize.JsonSerializeToFile(path, this);
        #endregion
        #region Save
        public void Save()
        {
            if (!string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName))
            {
                var v = this;
                Save(FileName);
                Edit = false;
            }
            else SaveAs();
        }
        #endregion
        #region SaveAs
        public void SaveAs()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Devinno Ladder File|*.dld";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileName = sfd.FileName;
                    Save(FileName);
                    Edit = false;
                }
            }
        }
        #endregion
        #endregion
    }
}
