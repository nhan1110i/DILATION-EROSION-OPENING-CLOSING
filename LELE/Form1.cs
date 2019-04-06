using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LELE
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public static int n;
        public static int giaTri = 0;
        Bitmap anhGoc;
        public static Bitmap preview;
        public static String tit = "";
        // function
        private Bitmap _toGray(Bitmap bm)
        {
            Bitmap anhXam = new Bitmap(bm);
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    Color cl = bm.GetPixel(i, j);
                    int xam = (int)(2 * cl.R + 5 * cl.G + cl.B) / 8;
                    anhXam.SetPixel(i, j, Color.FromArgb(xam, xam, xam));
                }
            }
            return anhXam;
        }
        private Bitmap _toBinary(Bitmap bm) {
            Bitmap binary = new Bitmap(_toGray(bm));
            for (int i = 0; i < binary.Width; i++) {
                for (int j = 0; j < binary.Height; j++) {
                    Color cl = binary.GetPixel(i, j);
                    if(cl.R >= 120){
                        binary.SetPixel(i,j,Color.FromArgb(255,255,255));
                    }else{
                        binary.SetPixel(i,j,Color.FromArgb(0,0,0));
                    }
                }
            }
            return binary;
        }
        private Bitmap _DilationBinaryImage(Bitmap bm, int n)
        {
            Bitmap dilationBinaryImage = new Bitmap(bm);
            Bitmap temp = new Bitmap(dilationBinaryImage);
            int i, j;
             for (i = n; i < dilationBinaryImage.Width-n; i++)
                {
                    for (j = n; j < dilationBinaryImage.Height-n; j++)
                    {
                        if (dilationBinaryImage.GetPixel(i, j).R == 0)
                        {
                            for (int k = 0; k < n; k++) {
                                temp.SetPixel(i + n, j, Color.FromArgb(0, 0, 0));
                                temp.SetPixel(i - n, j, Color.FromArgb(0, 0, 0));
                                temp.SetPixel(i, j + n, Color.FromArgb(0, 0, 0));
                                temp.SetPixel(i, j + n, Color.FromArgb(0, 0, 0));

                            }
                            
                        }
                    }
                }
             dilationBinaryImage = new Bitmap(temp);
             return dilationBinaryImage;
         }
        private Bitmap _ErosionBinaryImage(Bitmap bm, int n) {
            Bitmap erosionBinaryImage = new Bitmap(bm);
            Bitmap temp = new Bitmap(erosionBinaryImage);
            int i, j;

            for (i = n; i < erosionBinaryImage.Width-n; i++) {
                for (j = n; j < erosionBinaryImage.Height-n; j++) {
                      if (erosionBinaryImage.GetPixel(i, j).R == 0) {
                          for (int k = 0; k < n; k++) {
                              if (erosionBinaryImage.GetPixel(i, j + k).R == 255 || erosionBinaryImage.GetPixel(i, j - k).R == 255 || erosionBinaryImage.GetPixel(i + k, j).R == 255 || erosionBinaryImage.GetPixel(i - k, j).R == 255) {
                                  temp.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                                  break;
                              }
                          }

                    }
                }
            }
            erosionBinaryImage = new Bitmap(temp);
            return erosionBinaryImage;
            
        }
        private Bitmap _openingBinaryImage(Bitmap bm, int n) {
            Bitmap openingBinaryImage = new Bitmap(bm);
            openingBinaryImage = new Bitmap(_ErosionBinaryImage(openingBinaryImage, n));
            openingBinaryImage = new Bitmap(_DilationBinaryImage(openingBinaryImage, n));
            return openingBinaryImage;
        }
        private Bitmap _closingBinaryImage(Bitmap bm, int n) {
            Bitmap closingBinaryImage = new Bitmap(bm);
            closingBinaryImage = new Bitmap(_DilationBinaryImage(closingBinaryImage, n));
            closingBinaryImage = new Bitmap(_ErosionBinaryImage(closingBinaryImage, n));
            return closingBinaryImage;
        }
        private Bitmap _dilationGrayImage(Bitmap bm, int n) {
            Bitmap dilationGrayImage = new Bitmap(bm);
            Bitmap temp = new Bitmap(dilationGrayImage);
            int max = 0;
            int i, j;
            
            for (i = n; i < dilationGrayImage.Width - n; i++) {
                for (j = n; j < dilationGrayImage.Height - n; j++) {
                    for (int k = 0; k < n; k++) {
                        int[] arr = {max,dilationGrayImage.GetPixel(i, j).R, dilationGrayImage.GetPixel(i + k, j).R, dilationGrayImage.GetPixel(i - k, j).R, dilationGrayImage.GetPixel(i, j - k).R, dilationGrayImage.GetPixel(i, j + k).R };
                        max = _timMax(arr);
                    }
                    //temp[i, j] = max + giaTri;
                    if (max + giaTri < 256)
                    {
                        temp.SetPixel(i, j, Color.FromArgb(max + giaTri, max + giaTri, max + giaTri));
                    }
                    else {
                        temp.SetPixel(i, j, Color.FromArgb(max, max, max));
                    }
                    max = 0;
                }
            }
            dilationGrayImage = new Bitmap(temp);
            return dilationGrayImage;
        }
        private Bitmap _erosionGrayImage(Bitmap bm, int n) { 
            Bitmap erosionGrayImage = new Bitmap(bm);
            Bitmap temp = new Bitmap(erosionGrayImage);
            int min = 255;
            int i, j;
            for (i = n; i < erosionGrayImage.Width - n; i++) {
                for (j = n; j < erosionGrayImage.Height - n; j++) {
                    for (int k = 0; k < n; k++) {
                        int[] arr = { min,erosionGrayImage.GetPixel(i, j).R, erosionGrayImage.GetPixel(i + k, j).R, erosionGrayImage.GetPixel(i - k, j).R, erosionGrayImage.GetPixel(i, j - k).R, erosionGrayImage.GetPixel(i, j + k).R };
                        min = _timMin(arr);
                    }
                    //temp[i, j] = max + giaTri;
                    if (min - giaTri > 0)
                    {
                        temp.SetPixel(i, j, Color.FromArgb(min - giaTri, min - giaTri, min - giaTri));
                    }
                    else {
                        temp.SetPixel(i, j, Color.FromArgb(min, min, min));
                    }
                    min = 255;
                }
            }
            erosionGrayImage = new Bitmap(temp);
            return erosionGrayImage;
        }
        private Bitmap _openingGrayImage(Bitmap bm, int n) {
            Bitmap openingGrayImage = new Bitmap(bm);
            openingGrayImage = new Bitmap(_dilationGrayImage(_erosionGrayImage(openingGrayImage,n),n));
            return openingGrayImage;
        }
        private Bitmap _closingGrayImage(Bitmap bm, int n) {
            Bitmap closingGrayImage = new Bitmap(bm);
            closingGrayImage = new Bitmap(_erosionGrayImage(_dilationGrayImage(closingGrayImage, n), n));
            return closingGrayImage;
        }
        private int _timMax(int [] mt) {
            int max = 0;
            for (int i = 0; i < mt.Length; i++) {
                if (mt[i] > max) {
                    max = mt[i];
                }
            }
            return max;
        }
        private int _timMin(int[] mt) {
            int min = mt[0];
            for (int i = 0; i < mt.Length; i++) {
                if (mt[i] < min) {
                    min = mt[i];
                }
            }
            return min;
        }
        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                anhGoc = new Bitmap(ofg.FileName);
                ptrGoc.Image = anhGoc;
            }
        }

        private void btntoGray_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bitmap anhXam = new Bitmap(anhGoc);
            preview = new Bitmap(ptrGoc.Image);
            ptrGoc.Image = _toGray(anhXam);
            
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Bitmap binary = new Bitmap(anhGoc);
            preview = new Bitmap(ptrGoc.Image);
            ptrGoc.Image = _toBinary(binary);          
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void ptrGoc_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            if (ofg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                anhGoc = new Bitmap(ofg.FileName);
                ptrGoc.Image = anhGoc;
            }
        }

        private void btnBinaryDilation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMatrix mt = new frmMatrix();
            mt.ShowDialog();
            Bitmap brdilation = new Bitmap(_toBinary(anhGoc));
            preview = new Bitmap(_toBinary(anhGoc));
            ptrGoc.Image = _DilationBinaryImage(brdilation,n);
            
        }

        private void btnBinaryErosion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            preview = new Bitmap(_toBinary(anhGoc));
            frmMatrix mt = new frmMatrix();
            mt.ShowDialog();
            Bitmap brerosion = new Bitmap(_toBinary(anhGoc));
            ptrGoc.Image = _ErosionBinaryImage(brerosion, n);
            
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmpreview pr = new frmpreview();
            pr.Show();
        }

        private void btnBinaryOpening_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            preview = new Bitmap(_toBinary(anhGoc));
            Bitmap opening = new Bitmap(_toBinary(anhGoc));
            frmMatrix mt = new frmMatrix();
            mt.ShowDialog();
            opening = new Bitmap(_openingBinaryImage(opening,n));
            ptrGoc.Image = opening;

        }

        private void btnBinaryClosing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            preview = new Bitmap(_toBinary(anhGoc));
            Bitmap closing = new Bitmap(_toBinary(anhGoc));
            frmMatrix mt = new frmMatrix();
            mt.ShowDialog();
            closing = new Bitmap(_closingBinaryImage(closing, n));
            ptrGoc.Image = closing;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                ptrGoc.Image.Save(sfd.FileName, format);
            }
        }

        private void btnGrayErosion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrayMatrix gmt = new frmGrayMatrix();
            gmt.ShowDialog();
            preview = new Bitmap(_toGray(anhGoc));
            Bitmap grayErosion = new Bitmap(_toGray(anhGoc));
            grayErosion = new Bitmap(_erosionGrayImage(grayErosion, n));
            ptrGoc.Image = grayErosion;
        }

        private void btnGrayDilation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrayMatrix gmt = new frmGrayMatrix();
            gmt.ShowDialog();
            preview = new Bitmap(_toGray(anhGoc));
            Bitmap grayDilation = new Bitmap(_toGray(anhGoc));
            grayDilation = new Bitmap(_dilationGrayImage(grayDilation, n));
            ptrGoc.Image = grayDilation;

        }

        private void btnGrayOpening_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrayMatrix gmt = new frmGrayMatrix();
            gmt.ShowDialog();
            preview = new Bitmap(_toGray(anhGoc));
            Bitmap openingGrayImage = new Bitmap(_toGray(anhGoc));
            ptrGoc.Image = _openingGrayImage(openingGrayImage, n);
        }

        private void btnGrayClosing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGrayMatrix gmt = new frmGrayMatrix();
            gmt.ShowDialog();
            preview = new Bitmap(_toGray(anhGoc));
            Bitmap closingGrayImage = new Bitmap(_toGray(anhGoc));
            ptrGoc.Image = _closingGrayImage(closingGrayImage, n);
        }


    }
}
