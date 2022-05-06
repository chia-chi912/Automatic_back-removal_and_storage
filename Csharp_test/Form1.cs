using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Csharp_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Image ReSize(Image img, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, 0, 0, bitmap.Width, bitmap.Height);
            g.Dispose();
            return bitmap;
        }

        string s;
        int a;

        private void button1_Click(object sender, EventArgs e)
        {
            Image image;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                s = openFileDialog.FileName.Remove(openFileDialog.FileName.Length-4);
                label2.Text = s;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = image;
            }
            try
            {
                Image pictur1 = ReSize(pictureBox1.Image, new Size(28, 28));
                pictureBox1.Image = pictur1;

                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newBitmap1 = new Bitmap(Width, Height);
                Bitmap newBitmap2 = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        pixel = oldBitmap.GetPixel(x, y);
                        int r, g, b;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;

                        double grey = r * 0.299 + g * 0.587 + b * 0.114;
                        newBitmap1.SetPixel(x, y, Color.FromArgb((int)grey, (int)grey, (int)grey));
                    }
                this.pictureBox1.Image = newBitmap1;

                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        pixel = oldBitmap.GetPixel(x, y);
                        int r, g, b;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;

                        double grey = r * 0.299 + g * 0.587 + b * 0.114;
                        if (grey > 145)
                            grey = 255;
                        else
                            grey = 0;
                        newBitmap2.SetPixel(x, y, Color.FromArgb((int)grey, (int)grey, (int)grey));
                    }
                this.pictureBox2.Image = newBitmap2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            a = int.Parse(textBox1.Text);
            try
            {
                int Height = this.pictureBox1.Image.Height;
                int Width = this.pictureBox1.Image.Width;
                Bitmap newBitmap = new Bitmap(Width, Height);
                Bitmap oldBitmap = (Bitmap)this.pictureBox1.Image;
                Color pixel;
                for (int x = 0; x < Width; x++)
                    for (int y = 0; y < Height; y++)
                    {
                        pixel = oldBitmap.GetPixel(x, y);
                        int r, g, b;
                        r = pixel.R;
                        g = pixel.G;
                        b = pixel.B;

                        double grey = r * 0.299 + g * 0.587 + b * 0.114;
                        if (grey > a)
                            grey = 255;
                        else
                            grey = 0;
                        newBitmap.SetPixel(x, y, Color.FromArgb((int)grey, (int)grey, (int)grey));
                    }
                this.pictureBox3.Image = newBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)//SAVE
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bitmap Image|*.bmp";
                saveFileDialog.Title = "儲存圖片";
                saveFileDialog.FileName = s ;
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            this.pictureBox2.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }

        private void button4_Click(object sender, EventArgs e)//SAVE
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bitmap Image|*.bmp";
                saveFileDialog.Title = "儲存圖片";
                saveFileDialog.FileName = s ;
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            this.pictureBox3.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "訊息提示");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            a = a + 5;
            textBox1.Text = a.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            a = int.Parse(textBox1.Text);
            a = a - 5;
            textBox1.Text = a.ToString();
        }
    }
}
