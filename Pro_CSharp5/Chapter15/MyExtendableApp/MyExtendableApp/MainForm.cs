using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CommonSnappableTypes;
using System.Reflection;

namespace MyExtendableApp {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

       

        private void snapInModuleToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK) {
                if (dlg.FileName.Contains("CommonSnappableTypes")) {
                    MessageBox.Show("CommonSnappableTypes has no snap-ins!");
                } else if (!LoadExternalModule(dlg.FileName)) {
                     MessageBox.Show("Noting implements IAppFunctionality!");
                }
            }
        }

        bool LoadExternalModule(string path) {
            
            Assembly theSnapInAsm = null;
            try {
                theSnapInAsm = Assembly.LoadFrom(path);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
            var theClassTypes = from t in theSnapInAsm.GetTypes()
                              //  where t.IsClass && (t.GetInterface("IAppFunctionality") != null)
                                where t.IsClass && typeof(IAppFunctionality).IsAssignableFrom(t)
                                select t;

            bool foundSnapIn = false;
            foreach (Type t in theClassTypes) {
                foundSnapIn = true;
                IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);
                DisplayCompanyData(t);
            }
            return foundSnapIn;
                                
        }

        void DisplayCompanyData(Type t) {
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where (ci.GetType() == typeof(CompanyInfoAttribute))
                           select ci;

            foreach (CompanyInfoAttribute c in compInfo) {
                MessageBox.Show(c.CompanyUrl, string.Format("More info about {0} in", c.CompanyName));
            }
        }
    }
}
