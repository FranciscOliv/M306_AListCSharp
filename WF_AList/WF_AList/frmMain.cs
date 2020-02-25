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
    public partial class frmMain : Form
    {
        //Initialisation de la bd
        static MySQLConnect db = new MySQLConnect();

        public frmMain()
        {
            InitializeComponent();
        }


       



        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            frmAddAnime faa = new frmAddAnime();

            dr = faa.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                Bitmap img = (faa.AnimeCover == null) ? Properties.Resources.defaultImg : faa.AnimeCover;

                string logs = db.insertAnime(faa.AnimeName, DateTime.Now, img, faa.AnimeDescription);

                lblErrors.Text = logs;

            }
            else if (dr == DialogResult.Cancel)
            {
                faa.Close();
            }
        }

        private void showLoginForm()
        {           
            frmLogin fl = new frmLogin();
            fl.ShowDialog(this);            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            showLoginForm();
        }
    }
}
