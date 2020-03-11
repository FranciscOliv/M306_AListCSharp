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
        //Initialisation des variables globales
        MySQLConnect db = new MySQLConnect();
        List<Anime> lstAnimes = new List<Anime>();


        public frmMain()
        {
            InitializeComponent();
        }


        //EVENTS -----------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
            LoadAnime();
            if (lstAnimes != null && lstAnimes.Count > 0)
                ShowAllAnime();
            lblErrors.Text = string.Empty;

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logs = string.Empty;
            DialogResult dr = new DialogResult();
            frmAddAnime faa = new frmAddAnime();

            dr = faa.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                byte[] imgBlob = (faa.AnimeCover == null) ? ImageToBlob(Properties.Resources.defaultImg) : ImageToBlob(faa.AnimeCover);

                for (int i = 0; i < 10; i++)
                {
                    logs = db.insertAnime(faa.AnimeName, DateTime.Now, imgBlob, faa.AnimeDescription);

                }
                lblErrors.Text = logs;

                ShowAllAnime();

            }
            else if (dr == DialogResult.Cancel)
            {
                faa.Close();
            }
        }

        private void pbxCard_Click(object sender, EventArgs e)
        {
            string logs = string.Empty;
            PictureBox clickedPbx = (sender as PictureBox);
            int id = Convert.ToInt32(clickedPbx.AccessibleName.Replace("pbxCover", ""));

            DialogResult dr = new DialogResult();
            frmModifyAnime fma = new frmModifyAnime(lstAnimes.Find(x => x.Id == id));
            dr = fma.ShowDialog(this);

            if (dr == DialogResult.OK)//Bouton OK
            {
                byte[] imgBlob = ImageToBlob(fma.AnimeCover);
                logs = db.updateAnime(id, fma.AnimeName, fma.AnimeDescription, imgBlob);
            }
            else if (dr == DialogResult.Abort)//Bouton supprimer
            {
                logs = db.deleteAnime(id);
                fma.Close();
            }
            else if (dr == DialogResult.Cancel)//Bouton cancel
            {
                fma.Close();
            }

            //Mise a jour de la form 
            lblErrors.Text = logs;
            UpdateView();
        }
        private void raffraîchirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateView();
        }


        //FUNCTIONS-----------------------------------------------------------------------

        private void LoadAnime()
        {
            lstAnimes = db.GetAllAnimeInfo();
        }


        private byte[] ImageToBlob(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        //VIEW---------------------------------------------------------------------------
        private void ShowLoginForm()
        {
            frmLogin fl = new frmLogin();
            fl.ShowDialog(this);
        }

        private void UpdateView()
        {
            RemovePictureBox("pbxAnimeCover");
            ShowAllAnime();
        }
        public void ShowAllAnime()
        {
            //SPACING
            int widthOffset = 10;
            int heightOffset = 50;
            int margin = 10;

            //SIZING
            int pbxWidth = 100;
            int pbxHeight = 150;

            //Info load            
            LoadAnime();

            List<PictureBox> lstPbxAnime = new List<PictureBox>();

            for (int i = 0; i < lstAnimes.Count; i++)
            {
                //VERIFIES IF LINE IS FULL AND CREATES NEW LINE
                if ((widthOffset + pbxWidth) >= this.Width)
                {
                    widthOffset = 10;
                    heightOffset = heightOffset + pbxHeight + margin;

                    PictureBox myPb = new PictureBox();

                    myPb.Size = new Size(pbxWidth, pbxHeight);
                    myPb.Name = "pbxAnimeCover";
                    myPb.SizeMode = PictureBoxSizeMode.StretchImage;
                    myPb.AccessibleName = "pbxCover" + lstAnimes[i].Id.ToString();

                    myPb.Image = lstAnimes[i].CoverImage;
                    myPb.Click += new EventHandler(pbxCard_Click);
                    myPb.Location = new Point(widthOffset, heightOffset);
                    lstPbxAnime.Add(myPb);

                    this.Controls.Add(myPb);
                    widthOffset = widthOffset + pbxWidth + margin;
                }//FILLS THE LINE WITH NEW PBX
                else
                {
                    PictureBox myPb = new PictureBox();

                    myPb.Size = new Size(pbxWidth, pbxHeight);
                    myPb.Name = "pbxAnimeCover";
                    myPb.SizeMode = PictureBoxSizeMode.StretchImage;
                    myPb.AccessibleName = "pbxCover" + lstAnimes[i].Id.ToString();

                    myPb.Image = lstAnimes[i].CoverImage;
                    myPb.Click += new EventHandler(pbxCard_Click);
                    myPb.Location = new Point(widthOffset, heightOffset);

                    lstPbxAnime.Add(myPb);
                    this.Controls.Add(myPb);
                    widthOffset = widthOffset + pbxWidth + margin;

                }
            }
        }
        public void RemovePictureBox(string nameParam)
        {
            foreach (PictureBox pb in this.Controls.Find(nameParam, true))
            {
                this.Controls.Remove(pb);
                pb.Dispose();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
