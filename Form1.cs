using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SampleWithOpenCvSharp
{
    public partial class Form1 : Form
    {
        private Image oriImg;
        private Image edgeImg;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonReadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files(*.*)|*.*";
            ofd.Title = "Read image";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    oriImg = Image.FromFile(ofd.FileName);
                    pictureBoxMain.Image = oriImg;
                }
                catch
                {
                    pictureBoxMain.Image = null;
                }
            }
        }
    }
}
