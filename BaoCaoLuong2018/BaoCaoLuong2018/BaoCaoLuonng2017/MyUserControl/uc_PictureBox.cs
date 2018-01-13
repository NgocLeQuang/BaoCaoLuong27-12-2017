using System;
using System.Drawing;
using System.Windows.Forms;

namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyUserControl
{
    public partial class uc_PictureBox : UserControl
    {
        public int iZoomMinimum = 10;
        public int iZoomMax = 500;

        public uc_PictureBox()
        {
            InitializeComponent();
        }

        public void AllowZoom(bool b)
        {
            imageBox1.AllowZoom = b;
        }

        public String LoadImage(String strURL, String strFileName, int iZoomValue)
        {
            try
            {
                PictureBox temp = new PictureBox();
                temp.Load(strURL);
                this.imageBox1.Image = temp.Image;

                imageBox1.SizeMode = ImageGlass.ImageBoxSizeMode.Normal;

                this.imageBox1.Image.Tag = strFileName;

                imageBox1.Zoom = iZoomValue;
                imageBox1.ZoomChanged += imageBox1_ZoomChanged;
            }
            catch (System.Exception)
            {
                return "Error";
            }

            return "Ok";
        }

        public void SetMinMaxValue(int min, int max)
        {
            this.iZoomMinimum = min;
            iZoomMax = max;
        }

        private void imageBox1_ZoomChanged(object sender, EventArgs e)
        {
            if (imageBox1.Zoom < iZoomMinimum)
                imageBox1.Zoom = iZoomMinimum;
            if (imageBox1.Zoom > iZoomMax)
                imageBox1.Zoom = iZoomMax;
        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            imageBox1.SizeMode = ImageGlass.ImageBoxSizeMode.Normal;
        }

        private void imageBox1_MouseHover(object sender, EventArgs e)
        {
            imageBox1.AllowZoom = true;
        }

        private void imageBox1_MouseLeave(object sender, EventArgs e)
        {
            imageBox1.AllowZoom = false;
        }

        private void btn_Xoaytrai_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(imageBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipXY);
                imageBox1.Image = bmp;
            }
        }

        private void btn_xoayphai_Click(object sender, EventArgs e)
        {
            if (imageBox1.Image != null)
            {
                Bitmap bmp = new Bitmap(imageBox1.Image);
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                imageBox1.Image = bmp;
            }
        }
    }
}