using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace MultiTabledDataSetApp {
    public partial class MainForm : Form {

        private DataSet autoLotDS = new DataSet("AutoLot");

        private SqlCommandBuilder sqlCBInventory;
        private SqlCommandBuilder sqlCBCustomers;
        private SqlCommandBuilder sqlCBOrders;

        private SqlDataAdapter invTableAdapter;
        private SqlDataAdapter custTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        private string cnStr = string.Empty;

        public MainForm() {
            InitializeComponent();

            cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            invTableAdapter = new SqlDataAdapter("select * from Inventory", cnStr);
            custTableAdapter = new SqlDataAdapter("select * from Customers", cnStr);
            ordersTableAdapter = new SqlDataAdapter("select * from Orders", cnStr);

            sqlCBInventory = new SqlCommandBuilder(invTableAdapter);
            sqlCBCustomers = new SqlCommandBuilder(custTableAdapter);
            sqlCBOrders = new SqlCommandBuilder(ordersTableAdapter);

            invTableAdapter.Fill(autoLotDS, "Inventory");
            custTableAdapter.Fill(autoLotDS, "Customers");
            ordersTableAdapter.Fill(autoLotDS, "Orders");

            BuildTableRelationship();

            dataGridViewInventory.DataSource = autoLotDS.Tables["Inventory"];
            dataGridViewCustomers.DataSource = autoLotDS.Tables["Customers"];
            dataGridViewOrders.DataSource = autoLotDS.Tables["Orders"];
        }

        private void BuildTableRelationship() {
            DataRelation dr = new DataRelation("CustomerOrder",
                autoLotDS.Tables["Customers"].Columns["CustID"],
                autoLotDS.Tables["Orders"].Columns["CustID"]);
            autoLotDS.Relations.Add(dr);

            DataRelation dr1 = new DataRelation("InventoryOrder",
                autoLotDS.Tables["Inventory"].Columns["CarID"],
                autoLotDS.Tables["Orders"].Columns["CarID"]);
            autoLotDS.Relations.Add(dr1);
        }

        private void btnUpdateDatabse_Click(object sender, EventArgs e) {
            try {
                invTableAdapter.Update(autoLotDS, "Inventory");
                custTableAdapter.Update(autoLotDS, "Customers");
                ordersTableAdapter.Update(autoLotDS, "Orders");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, EventArgs e) {
            string strOrderInfo = string.Empty;
            
            
            int custID = int.Parse(txtCustID.Text);

            DataRow[] drsCust = autoLotDS.Tables["Customers"].Select(
                string.Format("CustID = {0}", custID));

            strOrderInfo += string.Format("Customer {0}: {1} {2}\n",
                drsCust[0]["CustID"],
                drsCust[0]["FirstName"],
                drsCust[0]["LastName"]);

            DataRow[] drsOrder = drsCust[0].GetChildRows(autoLotDS.Relations["CustomerOrder"]);
            foreach (DataRow order in drsOrder) {
                strOrderInfo += string.Format("----\nOrder Number: {0}\n", order["OrderID"]);

                DataRow[] drsInv = order.GetParentRows(autoLotDS.Relations["inventoryOrder"]);

                DataRow car = drsInv[0];
                strOrderInfo += string.Format("Make: {0}\n", car["Make"]);
                strOrderInfo += string.Format("Color: {0}\n", car["Color"]);
                strOrderInfo += string.Format("Pet Name: {0}\n", car["PetName"]);
            }
            MessageBox.Show(strOrderInfo, "Order Details");
        }
    }
}
