namespace Demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using Newtonsoft.Json.Linq;
    public partial class DelDevice : Form
    {
        public DelDevice()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(Demo.znConfig.znUser, Demo.znConfig.znPass);
                mod_zenoss.ZenossAPI.Connect(Credential, Demo.znConfig.ZenossUrl());
                JObject Result = mod_zenoss.ZenossAPI.RemoveDevice(txtDeviceName.Text, cboDeviceClass.Text);
                txtResult.Text = Result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DelDevice_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(Demo.znConfig.znUser, Demo.znConfig.znPass);
                mod_zenoss.ZenossAPI.Connect(Credential, Demo.znConfig.ZenossUrl());
                string Result = (mod_zenoss.ZenossAPI.RunMethod("/zport/dmd/Devices", "DeviceRouter", "/zport/dmd/Devices", "getTree")).ToString();
                foreach (var line in Result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.Contains("\"uid\""))
                    {
                        string[] temp = line.Trim().Split(new char[] { ':' });
                        string deviceClass = temp[1];
                        deviceClass = (deviceClass.Replace("\"", "")).Replace("/zport/dmd/Devices", "");
                        deviceClass = deviceClass.Substring(0, deviceClass.Length - 1);
                        cboDeviceClass.Items.Add(deviceClass.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
