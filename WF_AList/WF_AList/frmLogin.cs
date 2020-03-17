/// \file frmLogin.cs
/// \brief Alist, M306
/// \group CANAS Diogo, FONSECA Francisco, FUJISE Thomas, HOARAU Nicolas
/// \author FNSCD , I.DA-P4B CFPTI
/// \date 2020.03.17 , FNSCD , version initiale
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
            loginVerify();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Config.IsLogged)
            {
                Application.Exit();
            }
        }

        private void loginVerify()
        {
            bool emailExist = db.userExist(Email);
            if (emailExist)
            {
                bool pwdVerify = db.pwdVerify(Email, Pwd);
                if (pwdVerify)
                {
                    Config.IsLogged = true;
                    this.Close();                    
                }
                else
                {
                    lblInfo.Text = "Le mot de passe est faux";
                }
                

            }
            else
            {
                lblInfo.Text = "L'email n'existe pas";
            }
        }



        
    }
}
