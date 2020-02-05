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

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            //List<string>[] lst = db.Select();
        }

        private byte[] ImageToBlob(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            frmAddAnime faa = new frmAddAnime();

            dr = faa.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                byte[] imgBlob;
                
                if (faa.AnimeCover == null)
                {
                    imgBlob = ImageToBlob(Properties.Resources.defaultImg);
                }
                else
                {
                    imgBlob = ImageToBlob(faa.AnimeCover);
                }
                
                string logs = db.insertAnime(faa.AnimeName, DateTime.Now, imgBlob, faa.AnimeDescription);

                lblErrors.Text = logs;

            }
            else if (dr == DialogResult.Cancel)
            {
                faa.Close();
            }
        }

    }
}
