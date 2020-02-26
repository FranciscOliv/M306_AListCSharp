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
            LoadAnime();
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

            }
            else if (dr == DialogResult.Cancel)
            {
                faa.Close();
                LoadAnime();
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
            if (lstAnimes.Count > 0)
                pictureBox1.Image = lstAnimes[0].CoverImage;
        }

        private byte[] ImageToBlob(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        //public void ShowAllAnime()
        //{
        //    //SPACING
        //    int widthOffset = 10;
        //    int heightOffset = 30;
        //    int margin = 10;

        //    //SIZING
        //    int cardWidth = 150;
        //    int cardHeight = 218;

        //    //CARDS INFO
        //    lstCards = null;
        //    lstCards = db.getAllCardInfo();
        //    lstPbxCards = null;
        //    lstPbxCards = new List<PictureBox>();

        //    for (int i = 0; i < lstCards.Count; i++)
        //    {
        //        //VERIFIES IF LINE IS FULL AND CREATES NEW LINE
        //        if ((widthOffset + cardWidth) >= this.Width)
        //        {
        //            widthOffset = 10;
        //            heightOffset = heightOffset + cardHeight + margin;

        //            PictureBox myPb = new PictureBox();

        //            myPb.Size = new Size(cardWidth, cardHeight);
        //            myPb.Name = "pbxCardImage";
        //            myPb.SizeMode = PictureBoxSizeMode.StretchImage;
        //            myPb.AccessibleName = "pbxCard" + lstCards[i].Id.ToString();

        //            myPb.Image = lstCards[i].Img;
        //            myPb.Click += new EventHandler(pbxCard_Click);
        //            myPb.Location = new Point(widthOffset, heightOffset);
        //            lstPbxCards.Add(myPb);

        //            this.Controls.Add(myPb);
        //            widthOffset = widthOffset + cardWidth + margin;
        //        }//FILLS THE LINE WITH NEW PBX
        //        else
        //        {
        //            PictureBox myPb = new PictureBox();

        //            myPb.Size = new Size(cardWidth, cardHeight);
        //            myPb.Name = "pbxCardImage";
        //            myPb.SizeMode = PictureBoxSizeMode.StretchImage;
        //            myPb.AccessibleName = "pbxCard" + lstCards[i].Id.ToString();

        //            myPb.Image = lstCards[i].Img;
        //            myPb.Click += new EventHandler(pbxCard_Click);
        //            myPb.Location = new Point(widthOffset, heightOffset);

        //            lstPbxCards.Add(myPb);
        //            this.Controls.Add(myPb);
        //            widthOffset = widthOffset + cardWidth + margin;

        //        }
        //    }
        //}


    }
}
