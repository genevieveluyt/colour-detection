using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace Polygon_Detection
{
    public partial class Form1 : Form
    {

        struct Point
        {
            public int x, y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }

        List<Point> points;
        float straightAngleTolerance = 10; // in degrees
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetImage_Click(object sender, EventArgs e)
        {
            try
            {
                imgImage.Image = new Image<Rgb, Byte>("..\\..\\resources\\" + txtImagePath.Text);
            }
            catch (System.IO.FileNotFoundException)
            {
                txtResults.Text = "File not found";
            }
            catch (System.ArgumentException)
            {
                txtResults.Text = "Illegal characters in path";
            }
            
        }
    }
}
