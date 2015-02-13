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
    public partial class SetConfig : Form
    {
        public SetConfig()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Demo.znConfig.znServer = txtServer.Text;
            Demo.znConfig.znPort = Convert.ToInt16(txtPort.Text);
            Demo.znConfig.znUser = txtUser.Text;
            Demo.znConfig.znPass = txtPass.Text;
            Demo.znConfig.znSSL = chkSSL.Checked;
            this.Close();
        }

        private void SetConfig_Load(object sender, EventArgs e)
        {
            txtServer.Text = Demo.znConfig.znServer;
            if (Demo.znConfig.znPort == 0)
            {
                txtPort.Text = "80";
            }
            else
            {
                txtPort.Text = Demo.znConfig.znPort.ToString();
            }
            chkSSL.Checked = Demo.znConfig.znSSL;
            txtUser.Text = Demo.znConfig.znUser;
        }
    }
}
