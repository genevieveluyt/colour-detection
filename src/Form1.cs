using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace Polygon_Detection
{
    public partial class Form1 : Form
    {

        List<Point> points;
        float straightAngleTolerance = 10;  // in degrees
        Image<Rgb, Byte> img;
        String[] res;                       // filenames of files in resources
        int curImg;                         // index of file currently displayed in res array

        #region Form Setup

        public Form1()
        {
            InitializeComponent();
        }

        // When form loads, get paths of all files in resources folder and store
        // in String array and setup GUI with first file in the folder
        private void Form1_Load(object sender, EventArgs e)
        {
            res = Directory.GetFiles("..\\..\\resources");              // store paths of a files in resources folder

            if (res.Length == 0)                                        // if no files in resources folder, display message
            {
                imgImage.Image = null;
                txtOutput.Text = "resources folder is empty!";
                return;
            }

            try
            {                                                           // set up GUI with first file in resources folder
                curImg = 0;
                txtFileName.Text = Path.GetFileName(res[curImg]);
                img = new Image<Rgb, Byte>(res[curImg]);
                imgImage.Image = img;
            }
            catch (FileNotFoundException)
            {
                txtOutput.Text = "Unexpected file type found in resources";
            }
        }
        #endregion

        #region Button Click Events

        // Attempts to retrieve image from specified file name in GUI.
        // File must be in resources folder.
        private void btnGetImage_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            try
            {
                img = new Image<Rgb, Byte>("..\\..\\resources\\" + txtFileName.Text);
                imgImage.Image = img;
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i].Equals(txtFileName.Text))
                    {
                        curImg = i;
                        break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                txtOutput.Text = "File not found";
                imgImage.Image = null;
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Illegal characters in path";
                imgImage.Image = null;
            }
            
        }

        // When next button clicked, goes to next file in resources folder
        // If currently on last file, will go to the first file in the folder
        private void btnNextImg_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            curImg = curImg == res.Length-1 ? 0 : curImg+1;             // if on last file, go to first

            try
            {                                                           // try to store and display image
                txtFileName.Text = Path.GetFileName(res[curImg]);
                img = new Image<Rgb, Byte>(res[curImg]);
                imgImage.Image = img;
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type found";
                imgImage.Image = null;
            }
        }

        // When previous button clicked, goes to previous file in resources folder
        // If currently on first file, will go to last file in folder
        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            curImg = curImg == 0 ? res.Length-1 : curImg-1;         // if on first file, go to last

            try
            {                                                       // try to store and display image
                txtFileName.Text = Path.GetFileName(res[curImg]);
                img = new Image<Rgb, Byte>(res[curImg]);
                imgImage.Image = img;
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type found";
                imgImage.Image = null;
            }
        }
        #endregion

        struct Point
        {
            public int x, y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
    }
}
