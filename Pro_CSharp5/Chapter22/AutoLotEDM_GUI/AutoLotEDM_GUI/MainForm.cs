using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using AutoLotDAL;

namespace AutoLotEDM_GUI {
    public partial class MainForm : Form {

        AutoLotEntities context = new AutoLotEntities();
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            context.Inventories.Load();
            gridInventory.DataSource = context.Inventories.Local.ToBindingList();
            
        }

        private void button1_Click(object sender, EventArgs e) {
            using (AutoLotEntities context = new AutoLotEntities()) {
                string s = "";
                /*foreach (var item in context.Inventories) {
                   // s += item.CarID + "\n";
                } */
                MessageBox.Show("" + context.Inventories.Count());
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            context.SaveChanges();
            MessageBox.Show("Data saved");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            context.Dispose();
        }
    }
}
