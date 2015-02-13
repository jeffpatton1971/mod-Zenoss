namespace Demo
{
    partial class GetDevice
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
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmdOk = new System.Windows.Forms.Button();
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
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(90, 12);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(148, 20);
            this.txtDevice.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 38);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(223, 181);
            this.txtResult.TabIndex = 2;
            this.txtResult.TabStop = false;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(163, 225);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 3;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // GetDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 256);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Get Device From Zenoss";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button cmdOk;
    }
}