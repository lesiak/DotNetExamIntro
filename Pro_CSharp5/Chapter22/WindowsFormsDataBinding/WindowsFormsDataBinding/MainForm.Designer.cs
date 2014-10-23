namespace WindowsFormsDataBinding {
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
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnChangeMake = new System.Windows.Forms.Button();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(37, 25);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.RowTemplate.Height = 24;
            this.carInventoryGridView.Size = new System.Drawing.Size(932, 192);
            this.carInventoryGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveCar);
            this.groupBox1.Controls.Add(this.txtCarToRemove);
            this.groupBox1.Location = new System.Drawing.Point(37, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Car ID to Delete";
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(269, 22);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(152, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(7, 22);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(213, 22);
            this.txtCarToRemove.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChangeMake);
            this.groupBox2.Controls.Add(this.btnDisplayMakes);
            this.groupBox2.Controls.Add(this.txtMakeToView);
            this.groupBox2.Location = new System.Drawing.Point(520, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Make to View";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(269, 22);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(152, 23);
            this.btnDisplayMakes.TabIndex = 1;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(7, 22);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(213, 22);
            this.txtMakeToView.TabIndex = 0;
            // 
            // btnChangeMake
            // 
            this.btnChangeMake.Location = new System.Drawing.Point(273, 65);
            this.btnChangeMake.Name = "btnChangeMake";
            this.btnChangeMake.Size = new System.Drawing.Size(147, 32);
            this.btnChangeMake.TabIndex = 2;
            this.btnChangeMake.Text = "Change Make";
            this.btnChangeMake.UseVisualStyleBackColor = true;
            this.btnChangeMake.Click += new System.EventHandler(this.btnChangeMake_Click);
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(37, 362);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.RowTemplate.Height = 24;
            this.dataGridYugosView.Size = new System.Drawing.Size(932, 192);
            this.dataGridYugosView.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 665);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnChangeMake;
        private System.Windows.Forms.DataGridView dataGridYugosView;
    }
}

