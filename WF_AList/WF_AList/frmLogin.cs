using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_AList
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        static MySQLConnect db = new MySQLConnect();

        public string Email { get => tbxEmail.Text; }
        public string Pwd { get => tbxPwd.Text; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool ok = db.userExist(Email);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
