using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp {
    public partial class MainForm : Form {

        List<Car> carsInStock = null;
        
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            carsInStock = new List<Car>()
            {
                new Car() {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"}
            };

            UpdateGrid();

        }

        private void UpdateGrid() {
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e) {
            NewCarDialog dlg = new NewCarDialog();

            if (dlg.ShowDialog() == DialogResult.OK) {
                carsInStock.Add(dlg.theCar);
            }

            UpdateGrid();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e) {
            ExportToExcel(carsInStock);
        }

        static void ExportToExcel(List<Car> carsInStock) {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            excelApp.Visible = true;

            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";

            int row = 1;
            foreach (Car c in carsInStock) {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            //workSheet.Range["A1"].AutoFo

            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();

            MessageBox.Show("Export complete");

        }
    }

    
}
