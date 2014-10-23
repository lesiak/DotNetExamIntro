namespace FunWithCSharpAsync {
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnCallMethod = new System.Windows.Forms.Button();
            this.btnMultipleAwaits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 23);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(258, 22);
            this.txtInput.TabIndex = 0;
            // 
            // btnCallMethod
            // 
            this.btnCallMethod.Location = new System.Drawing.Point(13, 170);
            this.btnCallMethod.Name = "btnCallMethod";
            this.btnCallMethod.Size = new System.Drawing.Size(257, 24);
            this.btnCallMethod.TabIndex = 1;
            this.btnCallMethod.Text = "Call method";
            this.btnCallMethod.UseVisualStyleBackColor = true;
            this.btnCallMethod.Click += new System.EventHandler(this.btnCallMethod_Click);
            // 
            // btnMultipleAwaits
            // 
            this.btnMultipleAwaits.Location = new System.Drawing.Point(13, 200);
            this.btnMultipleAwaits.Name = "btnMultipleAwaits";
            this.btnMultipleAwaits.Size = new System.Drawing.Size(258, 23);
            this.btnMultipleAwaits.TabIndex = 2;
            this.btnMultipleAwaits.Text = "Multiple Awaits";
            this.btnMultipleAwaits.UseVisualStyleBackColor = true;
            this.btnMultipleAwaits.Click += new System.EventHandler(this.btnMultipleAwaits_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 255);
            this.Controls.Add(this.btnMultipleAwaits);
            this.Controls.Add(this.btnCallMethod);
            this.Controls.Add(this.txtInput);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnCallMethod;
        private System.Windows.Forms.Button btnMultipleAwaits;
    }
}

