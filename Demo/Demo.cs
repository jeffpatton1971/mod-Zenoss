using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
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
    }
    public static class znConfig
    {
        public static string znUrl { get; set; }
        public static string znUser { get; set; }
        public static string znPass { get; set; }
    }
}
