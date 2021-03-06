﻿namespace Demo
{
    using System;
    using System.Windows.Forms;

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdSetConfig_Click(object sender, EventArgs e)
        {
            SetConfig setConfig = new SetConfig();
            setConfig.Visible = true;
        }

        private void cmdGetDevice_Click(object sender, EventArgs e)
        {
            GetDevice getDevice = new GetDevice();
            getDevice.Visible = true;
        }

        private void cmdAddDevice_Click(object sender, EventArgs e)
        {
            AddDevice addDevice = new AddDevice();
            addDevice.Visible = true;
        }

        private void cmdDelDevice_Click(object sender, EventArgs e)
        {
            DelDevice delDevice = new DelDevice();
            delDevice.Visible = true;
        }
    }
    public static class znConfig
    {
        public static string znServer { get; set; }
        public static int znPort { get; set; }
        public static string znUser { get; set; }
        public static string znPass { get; set; }
        public static bool znSSL { get; set; }
        public static string ZenossUrl()
        {
            if (znSSL == true)
            {
                return "https://" + znServer;
            }
            else
            {
                return "http://" + znServer + ":" + znPort;
            }
        }
    }
}