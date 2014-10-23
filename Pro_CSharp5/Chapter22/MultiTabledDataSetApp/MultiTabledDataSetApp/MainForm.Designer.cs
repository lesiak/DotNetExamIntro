namespace MultiTabledDataSetApp {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.btnUpdateDatabse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustID = new System.Windows.Forms.TextBox();
            this.btnGetOrderInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Inventory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Customers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current Orders";
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.Location = new System.Drawing.Point(30, 58);
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.RowTemplate.Height = 24;
            this.dataGridViewInventory.Size = new System.Drawing.Size(999, 113);
            this.dataGridViewInventory.TabIndex = 3;
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(33, 215);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.RowTemplate.Height = 24;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(999, 113);
            this.dataGridViewCustomers.TabIndex = 4;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(30, 365);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowTemplate.Height = 24;
            this.dataGridViewOrders.Size = new System.Drawing.Size(999, 113);
            this.dataGridViewOrders.TabIndex = 5;
            // 
            // btnUpdateDatabse
            // 
            this.btnUpdateDatabse.Location = new System.Drawing.Point(845, 519);
            this.btnUpdateDatabse.Name = "btnUpdateDatabse";
            this.btnUpdateDatabse.Size = new System.Drawing.Size(184, 23);
            this.btnUpdateDatabse.TabIndex = 6;
            this.btnUpdateDatabse.Text = "Update DB";
            this.btnUpdateDatabse.UseVisualStyleBackColor = true;
            this.btnUpdateDatabse.Click += new System.EventHandler(this.btnUpdateDatabse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetOrderInfo);
            this.groupBox1.Controls.Add(this.txtCustID);
            this.groupBox1.Location = new System.Drawing.Point(33, 519);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lookup Customer Order";
            // 
            // txtCustID
            // 
            this.txtCustID.Location = new System.Drawing.Point(7, 22);
            this.txtCustID.Name = "txtCustID";
            this.txtCustID.Size = new System.Drawing.Size(180, 22);
            this.txtCustID.TabIndex = 0;
            // 
            // btnGetOrderInfo
            // 
            this.btnGetOrderInfo.Location = new System.Drawing.Point(7, 71);
            this.btnGetOrderInfo.Name = "btnGetOrderInfo";
            this.btnGetOrderInfo.Size = new System.Drawing.Size(180, 23);
            this.btnGetOrderInfo.TabIndex = 1;
            this.btnGetOrderInfo.Text = "Get Order Details";
            this.btnGetOrderInfo.UseVisualStyleBackColor = true;
            this.btnGetOrderInfo.Click += new System.EventHandler(this.btnGetOrderInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 628);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdateDatabse);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button btnUpdateDatabse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetOrderInfo;
        private System.Windows.Forms.TextBox txtCustID;
    }
}

