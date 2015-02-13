namespace Demo
{
    partial class frmMain
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
            this.cmdSetConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdGetDevice = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdAddDevice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdDelDevice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Setup your Zenoss config";
            // 
            // cmdSetConfig
            // 
            this.cmdSetConfig.Location = new System.Drawing.Point(15, 25);
            this.cmdSetConfig.Name = "cmdSetConfig";
            this.cmdSetConfig.Size = new System.Drawing.Size(92, 23);
            this.cmdSetConfig.TabIndex = 1;
            this.cmdSetConfig.Text = "Set Config";
            this.cmdSetConfig.UseVisualStyleBackColor = true;
            this.cmdSetConfig.Click += new System.EventHandler(this.cmdSetConfig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Get a device from Zenoss";
            // 
            // cmdGetDevice
            // 
            this.cmdGetDevice.Location = new System.Drawing.Point(15, 76);
            this.cmdGetDevice.Name = "cmdGetDevice";
            this.cmdGetDevice.Size = new System.Drawing.Size(92, 23);
            this.cmdGetDevice.TabIndex = 3;
            this.cmdGetDevice.Text = "Get Device";
            this.cmdGetDevice.UseVisualStyleBackColor = true;
            this.cmdGetDevice.Click += new System.EventHandler(this.cmdGetDevice_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add a device to Zenoss";
            // 
            // cmdAddDevice
            // 
            this.cmdAddDevice.Location = new System.Drawing.Point(15, 129);
            this.cmdAddDevice.Name = "cmdAddDevice";
            this.cmdAddDevice.Size = new System.Drawing.Size(92, 23);
            this.cmdAddDevice.TabIndex = 5;
            this.cmdAddDevice.Text = "Add Device";
            this.cmdAddDevice.UseVisualStyleBackColor = true;
            this.cmdAddDevice.Click += new System.EventHandler(this.cmdAddDevice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remove a device from Zenoss";
            // 
            // cmdDelDevice
            // 
            this.cmdDelDevice.Location = new System.Drawing.Point(15, 181);
            this.cmdDelDevice.Name = "cmdDelDevice";
            this.cmdDelDevice.Size = new System.Drawing.Size(92, 23);
            this.cmdDelDevice.TabIndex = 7;
            this.cmdDelDevice.Text = "Remove Device";
            this.cmdDelDevice.UseVisualStyleBackColor = true;
            this.cmdDelDevice.Click += new System.EventHandler(this.cmdDelDevice_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmdDelDevice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdAddDevice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdGetDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSetConfig);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Zenoss Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSetConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdGetDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdAddDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdDelDevice;
    }
}

