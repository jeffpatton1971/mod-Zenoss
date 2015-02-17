﻿namespace Demo
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    using System.IO;
    using System.Windows.Forms;
    public partial class AddDevice : Form
    {
        public AddDevice()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = "";
                JObject AddDevice = null;
                NetworkCredential Credential = new NetworkCredential(Demo.znConfig.znUser, Demo.znConfig.znPass);
                mod_zenoss.ZenossAPI.Connect(Credential, Demo.znConfig.ZenossUrl());
                //
                // Must have a valid DeviceClass in order to add
                //
                AddDevice = mod_zenoss.ZenossAPI.AddDevice(txtDeviceName.Text, cboDeviceClass.Text);
                MessageBox.Show(AddDevice.ToString());
                JObject jResult = mod_zenoss.ZenossAPI.FindDevice(txtDeviceName.Text);
                txtResult.Text = jResult.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void AddDevice_Load(object sender, EventArgs e)
        {
            try
            {
                NetworkCredential Credential = new NetworkCredential(Demo.znConfig.znUser, Demo.znConfig.znPass);
                mod_zenoss.ZenossAPI.Connect(Credential, Demo.znConfig.ZenossUrl());
                string Result = (mod_zenoss.ZenossAPI.GetTree("/zport/dmd/Devices", "DeviceRouter", "/zport/dmd/Devices")).ToString();
                string settingsResult = (mod_zenoss.ZenossAPI.GetTree("/zport/dmd/UserInterfaceSettings", "SettingsRouter", "/zport/dmd/UserInterfaceSettings")).ToString();
                Console.WriteLine(settingsResult);
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