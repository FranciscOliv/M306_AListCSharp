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
    public partial class frmAddAnime : Form
    {
        public frmAddAnime()
        {
            InitializeComponent();
        }
        
        private Bitmap _animeCover;
        private int IMG_WIDTH = Config.Img_width;
        private int IMG_HEIGH = Config.Img_height;

        public string AnimeName { get => tbxName.Text;}
        public string AnimeDescription { get => tbxDescription.Text;}
        public Bitmap AnimeCover { get => _animeCover; set => _animeCover = value; }

        private void btnAddCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            fileOpen.Title = "Chose an image";            
            fileOpen.Filter = "Image Files(*.BMP;*.PNG; *.JPG)|*.BMP;*.PNG;*.JPG";

            if (fileOpen.ShowDialog() == DialogResult.OK) { 
                AnimeCover = new Bitmap(Image.FromFile(fileOpen.FileName), IMG_WIDTH, IMG_HEIGH);               
         
            }

            fileOpen.Dispose();           

        }
    }
}
