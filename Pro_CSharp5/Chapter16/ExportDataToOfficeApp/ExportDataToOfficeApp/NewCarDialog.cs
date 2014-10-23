using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportDataToOfficeApp {
    public partial class NewCarDialog : Form {

        public Car theCar = null;
        
        public NewCarDialog() {
            InitializeComponent();
        }

        private void cancleButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (tbColor.Text.Length > 0 && tbmake.Text.Length > 0 && tbPetname.Text.Length > 0) {
                theCar = new Car { Color = tbColor.Text, Make = tbmake.Text, PetName = tbPetname.Text };
                this.DialogResult = DialogResult.OK;
            }
        }

        
    }
}
