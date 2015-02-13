namespace Demo
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    using System.Windows.Forms;
    public partial class GetDevice : Form
    {
        public GetDevice()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            NetworkCredential Credential = new NetworkCredential(Demo.znConfig.znUser, Demo.znConfig.znPass);
            mod_zenoss.ZenossAPI.Connect(Credential, Demo.znConfig.ZenossUrl());
            JObject Result = mod_zenoss.ZenossAPI.FindDevice(txtDevice.Text);
            txtResult.Text = Result.ToString();
        }
    }
}
