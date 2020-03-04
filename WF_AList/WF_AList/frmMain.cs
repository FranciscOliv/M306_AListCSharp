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
        MySQLConnect db = new MySQLConnect();
        List<Anime> lstAnimes = new List<Anime>();


        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowLoginForm();
            ShowAllAnime();

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            frmAddAnime faa = new frmAddAnime();

            dr = faa.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                byte[] imgBlob = (faa.AnimeCover == null) ? ImageToBlob(Properties.Resources.defaultImg) : ImageToBlob(faa.AnimeCover);

                string logs = db.insertAnime(faa.AnimeName, DateTime.Now, imgBlob, faa.AnimeDescription);

                lblErrors.Text = logs;
                ShowAllAnime();

            }
            else if (dr == DialogResult.Cancel)
            {
                faa.Close();
            }
        }

        private void ShowLoginForm()
        {
            frmLogin fl = new frmLogin();
            fl.ShowDialog(this);
        }

        private void LoadAnime()
        {
            lstAnimes = db.GetAllAnimeInfo();
        }

        private byte[] ImageToBlob(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void pbxCard_Click(object sender, EventArgs e)
        {
            PictureBox clickedPbx = (sender as PictureBox);
            int id = Convert.ToInt32(clickedPbx.AccessibleName.Replace("pbxCard", ""));

            DialogResult dr = new DialogResult();
            frmModifyAnime fma = new frmModifyAnime();
            dr = fma.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                              

                
            }
        }


        public void ShowAllAnime()
        {
            //SPACING
            int widthOffset = 10;
            int heightOffset = 30;
            int margin = 10;

            //SIZING
            int pbxWidth = Config.Img_width;
            int pbxHeight = Config.Img_height;

            //Info load
            // if (lstAnimes == null || lstAnimes.Count > 0)
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
                    //myPb.Click += new EventHandler(pbxCard_Click);
                    myPb.Location = new Point(widthOffset, heightOffset);

                    lstPbxAnime.Add(myPb);
                    this.Controls.Add(myPb);
                    widthOffset = widthOffset + pbxWidth + margin;

                }
            }
        }


    }
}
