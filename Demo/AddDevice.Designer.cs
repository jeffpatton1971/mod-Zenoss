namespace Demo
{
    partial class AddDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.cmdOk = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cboDeviceClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Device Class";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(90, 12);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(137, 20);
            this.txtDeviceName.TabIndex = 2;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(152, 64);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 93);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(212, 180);
            this.txtResult.TabIndex = 5;
            this.txtResult.TabStop = false;
            // 
            // cboDeviceClass
            // 
            this.cboDeviceClass.DropDownWidth = 255;
            this.cboDeviceClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDeviceClass.FormattingEnabled = true;
            this.cboDeviceClass.Location = new System.Drawing.Point(90, 37);
            this.cboDeviceClass.Name = "cboDeviceClass";
            this.cboDeviceClass.Size = new System.Drawing.Size(137, 21);
            this.cboDeviceClass.TabIndex = 6;
            // 
            // AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 285);
            this.Controls.Add(this.cboDeviceClass);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Device to Zenoss";
            this.Load += new System.EventHandler(this.AddDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cboDeviceClass;
    }
}