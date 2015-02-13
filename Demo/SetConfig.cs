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
            Demo.znConfig.znUrl = txtUrl.Text;
            Demo.znConfig.znUser = txtUser.Text;
            Demo.znConfig.znPass = txtPass.Text;
            Demo.znConfig.znSSL = chkSSL.Checked;
            this.Close();
        }

        private void SetConfig_Load(object sender, EventArgs e)
        {
            txtUrl.Text = Demo.znConfig.znUrl;
            txtUser.Text = Demo.znConfig.znUser;
        }
    }
}
