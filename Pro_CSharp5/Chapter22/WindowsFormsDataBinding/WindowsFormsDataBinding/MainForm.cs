using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataBinding {
    public partial class MainForm : Form {

        List<Car> listCars = null;

        DataTable inventoryTable = new DataTable();

        DataView yugosOnlyView;

        public MainForm() {
            InitializeComponent();

            listCars = new List<Car>() {
                new Car {ID = 100, PetName = "Henry", Color = "Silver",  Make = "BMW"},
                new Car {ID = 101, PetName = "Daisy", Color = "Tan",  Make = "BMW"},
                new Car {ID = 102, PetName = "Mary", Color = "Black",Make = "VW"},
                new Car {ID = 103, PetName = "Clunker", Color = "Rust",Make = "Yugo"},
                new Car {ID = 104, PetName = "Melvin", Color = "White", Make = "Ford"}
              };
            CreateDataTable();
            CreateDataView();
        }

        void CreateDataTable() {
            DataColumn carIDColumn = new DataColumn("ID", typeof(int));
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });
            foreach (Car c in listCars) {
                DataRow newRow = inventoryTable.NewRow();
                newRow["ID"] = c.ID;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;
                inventoryTable.Rows.Add(newRow);
            }
            carInventoryGridView.DataSource = inventoryTable;
        }

        void CreateDataView() {
            yugosOnlyView = new DataView(inventoryTable);
            yugosOnlyView.RowFilter = "Make = 'Yugo'";
            dataGridYugosView.DataSource = yugosOnlyView;
        }

        private void btnRemoveCar_Click(object sender, EventArgs e) {
            try {
                DataRow[] rowToDelete = inventoryTable.Select(string.Format("ID={0}", int.Parse(txtCarToRemove.Text)));

                rowToDelete[0].Delete();
                inventoryTable.AcceptChanges();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDisplayMakes_Click(object sender, EventArgs e) {
            string filterStr = string.Format("Make = '{0}'", txtMakeToView.Text);

            DataRow[] makes = inventoryTable.Select(filterStr, "PetName");

            if (makes.Length == 0) {
                MessageBox.Show("No Cars", "Selection Error");
            } else {
                string strMake = "";
                for (int i = 0; i < makes.Length; i++) {
                    strMake += makes[i]["PetName"] + "\n";
                }
                MessageBox.Show(strMake, string.Format("We have {0}s named:", txtMakeToView.Text));
            }
        }

        private void btnChangeMake_Click(object sender, EventArgs e) {
            string filterStr = string.Format("Make = '{0}'", txtMakeToView.Text);
            DataRow[] makes = inventoryTable.Select(filterStr);
            foreach (DataRow dr in makes) {
                dr["Make"] = "Yugo";
            }
            
        }
    }
}
