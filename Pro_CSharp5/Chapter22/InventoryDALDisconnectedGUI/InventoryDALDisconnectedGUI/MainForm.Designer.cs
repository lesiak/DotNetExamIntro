﻿namespace InventoryDALDisconnectedGUI {
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
            this.inventoryGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdateInventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // inventoryGrid
            // 
            this.inventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGrid.Location = new System.Drawing.Point(29, 28);
            this.inventoryGrid.Name = "inventoryGrid";
            this.inventoryGrid.RowTemplate.Height = 24;
            this.inventoryGrid.Size = new System.Drawing.Size(1004, 413);
            this.inventoryGrid.TabIndex = 0;
            // 
            // btnUpdateInventory
            // 
            this.btnUpdateInventory.Location = new System.Drawing.Point(855, 463);
            this.btnUpdateInventory.Name = "btnUpdateInventory";
            this.btnUpdateInventory.Size = new System.Drawing.Size(178, 23);
            this.btnUpdateInventory.TabIndex = 1;
            this.btnUpdateInventory.Text = "Update!";
            this.btnUpdateInventory.UseVisualStyleBackColor = true;
            this.btnUpdateInventory.Click += new System.EventHandler(this.btnUpdateInventory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 516);
            this.Controls.Add(this.btnUpdateInventory);
            this.Controls.Add(this.inventoryGrid);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView inventoryGrid;
        private System.Windows.Forms.Button btnUpdateInventory;
    }
}

