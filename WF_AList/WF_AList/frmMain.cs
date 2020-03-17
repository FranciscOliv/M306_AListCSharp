/// \file frmMain.cs
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
    public partial class frmMain : Form
    {
        //Initialisation des variables globales
        private MySQLConnect db;
        private List<Anime> lstAnimes;
        private string[] logs;

        public frmMain()
        {
            InitializeComponent();
        }


        //FORM EVENTS-----------------------------------------------------------------
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Initialisation des variables
            db = new MySQLConnect();
            lstAnimes = new List<Anime>();
            logs = new string[2];


            //Initialisation de la form
            ShowLoginForm();
            LoadAnime();
            if (lstAnimes != null && lstAnimes.Count > 0)
                ShowAllAnime();

        }

        //CREATE
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            frmAddAnime faa = new frmAddAnime();

            dr = faa.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                byte[] imgBlob = (faa.AnimeCover == null) ? ImageToBlob(Properties.Resources.defaultImg) : ImageToBlob(faa.AnimeCover);

                logs = db.insertAnime(faa.AnimeName, DateTime.Now, imgBlob, faa.AnimeDescription);

            }
            else if (dr == DialogResult.Cancel)
            {
                logs = null;
                faa.Close();
            }
            //Mise a jour de la form             
            UpdateView();
            ShowLogs();


        }

        //UPDATE and DELETE
        private void pbxCard_Click(object sender, EventArgs e)
        {
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
                logs = null;
            }


            //Mise a jour de la form             
            UpdateView();
            ShowLogs();
        }
        private void raffraîchirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateView();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //FUNCTIONS-----------------------------------------------------------------------

        //READ
        private void LoadAnime()
        {
            lstAnimes = db.GetAllAnimeInfo();
        }

        //ERRORS AND INFO DISPLAY
        private void ShowLogs()
        {
            if (logs != null)
            {
                if (logs.Length > 0)
                {
                    string caption = string.Empty;
                    if (logs[0] == "true")
                    {
                        caption = "Succès";
                    }
                    else
                    {
                        caption = "Erreur";
                    }

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(logs[1], caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Closes the parent form.
                        this.Close();
                    }
                }

            }
        }

        //IMAGE CONVERT
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
            RemoveLabel("lblAnimeCover");
            ShowAllAnime();
        }
        public void ShowAllAnime()
        {
            //SPACING
            int widthOffset = 10;
            int heightOffset = 30;
            int marginBottom = 8;
            int marginRight = 10;

            //SIZING
            int pbxWidth = 100;
            int pbxHeight = 150;
            int lblHeight = 30;

            //Info load            
            LoadAnime();

            for (int i = 0; i < lstAnimes.Count; i++)
            {
                //VERIFIES IF LINE IS FULL AND CREATES NEW LINE
                if ((widthOffset + pbxWidth) >= this.Width)
                {
                    widthOffset = 10;
                    heightOffset = heightOffset + pbxHeight + marginBottom + lblHeight;

                    PictureBox myPb = new PictureBox();
                    Label myLbl = new Label();

                    myPb.Size = new Size(pbxWidth, pbxHeight);
                    myPb.Name = "pbxAnimeCover";
                    myPb.SizeMode = PictureBoxSizeMode.StretchImage;
                    myPb.AccessibleName = "pbxCover" + lstAnimes[i].Id.ToString();
                    myPb.Image = lstAnimes[i].CoverImage;
                    myPb.Click += new EventHandler(pbxCard_Click);
                    myPb.Location = new Point(widthOffset, heightOffset);



                    myLbl.Size = new Size(pbxWidth, lblHeight);
                    myLbl.Name = "lblAnimeCover";
                    myLbl.Text = lstAnimes[i].Name;
                    myLbl.TextAlign = ContentAlignment.TopCenter;
                    myLbl.Padding = new Padding(0, 3, 0, 0);
                    myLbl.Font = new Font("Arial Rounded MT Bold", 8);
                    myLbl.Location = new Point(widthOffset, heightOffset + pbxHeight);



                    this.Controls.Add(myLbl);
                    this.Controls.Add(myPb);
                    widthOffset = widthOffset + pbxWidth + marginRight;
                }//FILLS THE LINE WITH NEW PBX
                else
                {
                    PictureBox myPb = new PictureBox();
                    Label myLbl = new Label();

                    myPb.Size = new Size(pbxWidth, pbxHeight);
                    myPb.Name = "pbxAnimeCover";
                    myPb.SizeMode = PictureBoxSizeMode.StretchImage;
                    myPb.AccessibleName = "pbxCover" + lstAnimes[i].Id.ToString();
                    myPb.Image = lstAnimes[i].CoverImage;
                    myPb.Click += new EventHandler(pbxCard_Click);
                    myPb.Location = new Point(widthOffset, heightOffset);


                    myLbl.Size = new Size(pbxWidth, lblHeight);
                    myLbl.Name = "lblAnimeCover";
                    myLbl.Text = lstAnimes[i].Name;
                    myLbl.TextAlign = ContentAlignment.TopCenter;
                    myLbl.Padding = new Padding(0, 3, 0, 0);
                    myLbl.Font = new Font("Arial Rounded MT Bold", 8);
                    myLbl.Location = new Point(widthOffset, heightOffset + pbxHeight);

                    this.Controls.Add(myPb);
                    this.Controls.Add(myLbl);
                    widthOffset = widthOffset + pbxWidth + marginRight;

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
        public void RemoveLabel(string nameParam)
        {
            foreach (Label lbl in this.Controls.Find(nameParam, true))
            {
                this.Controls.Remove(lbl);
                lbl.Dispose();
            }
        }




    }
}
