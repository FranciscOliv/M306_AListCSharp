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
    public partial class frmModifyAnime : Form
    {
        private Bitmap _animeCover;
        private int IMG_WIDTH = Config.Img_width;
        private int IMG_HEIGH = Config.Img_height;
        private Anime currentAnime;



        public string AnimeName { get => tbxName.Text; set => tbxName.Text = value; }
        public string AnimeDescription { get => tbxDescription.Text; set => tbxDescription.Text = value; }
        public Bitmap AnimeCover { get => _animeCover; set => _animeCover = value; }


        public frmModifyAnime(Anime animeParam)
        {
            InitializeComponent();
            this.currentAnime = animeParam;


        }
        private void frmModifyAnime_Load(object sender, EventArgs e)
        {
            LoadFields();            
        }

        private void LoadFields()
        {
            AnimeName = currentAnime.Name;
            AnimeDescription = currentAnime.Description;
            AnimeCover = currentAnime.CoverImage;
            pbxAnimeImage.Image = AnimeCover;
        }


        private void btnModifyCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Chose an image";
            fileOpen.Filter = "Image Files(*.BMP;*.PNG; *.JPG)|*.BMP;*.PNG;*.JPG";

            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                string test = fileOpen.FileName;
                
                    AnimeCover = new Bitmap(Image.FromFile(fileOpen.FileName), IMG_WIDTH, IMG_HEIGH);
                    pbxAnimeImage.Image = AnimeCover;

                

            }

            fileOpen.Dispose();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if(tbxName.Text !=string.Empty && tbxDescription.Text != string.Empty)
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }
    }
}
