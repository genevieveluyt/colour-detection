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
        float straightAngleTolerance = 10;      // in degrees
        Image<Rgb, Byte> img;
        String relPath = "..\\..\\test_images"; // relative path location of files
        String[] filePaths;                     // filenames of files in folder with files
        int curFile;                            // index of file currently displayed in filePaths array


        #region Find Shape

        // use this as main, right now it runs every time an image
        // is displayed in the GUI
        public void findShape(Image<Rgb, Byte> image)
        {
            points = getPoints(image);
            points = getOuterPoints(points);
            points = removeStraightAngles(points);

            if (isShape(points)) {
                if (!txtOutput.Text.Equals(""))                 // if textbox is not empty, insert new line first
                    txtOutput.AppendText(Environment.NewLine);
                txtOutput.AppendText(determineShape(points));
            }
            else
            {
                if (!txtOutput.Text.Equals(""))
                    txtOutput.AppendText(Environment.NewLine);
                txtOutput.AppendText("No shape found");
            }

        }

        /* Attempts to locate all corners in an image
         * @return List<Point> list of coordinates
         */
        public List<Point> getPoints(Image<Rgb, Byte> image) {
            // Corner Harris
            // return list of points

            return null;
        }

        /* Isolates 'outer points' of a set of coordinates.
         * That is, imagine an elastic wrapped around the set of points.
         * Those touching the elastic are considered 'outer points'
         * @return List<Point> list of coordinates of 'outer points' in
         *      (counter)clockwise order
         */
        public List<Point> getOuterPoints(List<Point> points) {
            // Convex Hull
            // return list of points

            return null;
        }

        /* If angle between any three consecutive points is close to 180
         * (by margin of straightAngleTolerance), removes middle point
         * @param List<Point> list of points that make outline of shape
         *      in (counter)clockwise order
         * @return List<Point> list of points identical to list passed in
         *      excluding those in the middle of straight angles
         */
        public List<Point> removeStraightAngles(List<Point> points) {
            // for (every three consecutive points, a, b, and c) {
            //     angle = getSmallestAngle(a, b, c)
            //     if (angle is between 180+straightAngleTolerance and 180-straightAngleTolerance) {
            //         remove point b from list
            //     }
            // }
            // return list of points

            return null;
        }

        /* Identifies the smallest angle between lines a-b and b-c
         * ie. if 90 degrees and 270 degrees are possible, will return 90
         * @return double smallest angle in degrees
         */
        public double getSmallestAngle(Point a, Point b, Point c) {
            // vector A = vector a - vector b        // A.x = a.x - b.x; A.y = a.y - b.y
            //     vector B = vector c - vector b
            //     angle = arccos ( (vector A dot product vector B) / (magnitude vector A * magnitude vector B) )    
            // use Math.Acos() for arccos which gives radians
            //         // there is a radiansToDegrees method in the AERO code already??
            //         // dot product is A.x * B.x + A.y * B.y
            //         // magnitude of vector A is sqrt( (A.x)^2 + (A.y)^2 )
    
            //     return (angle is less than 180 ? angle : 180 - angle)
            //         // ternary operator

            return 0;
        }

        /* Attempts to determine if there is significant evidence that a
         * set of points makes the outline of a polygon
         * @return true if between 3 and 8 points (inclusive)
         */
        public bool isShape(List<Point> points) {
            //     if (list length more than 8)
            //         return false;
            //     else if (list length less than 8)
            //         return false;
            //     else
            //         return true;

            return false;
        }

        /* Attempts to determine what shape a set of points makes the outline of
         * @return one of "triangle", "rectangle", "pentagon", "hexagon",
         *      "heptagon", "octagon", or "unrecognized shape"
         */
        public String determineShape(List<Point> points) {
            // switch (list length ie number of corners) {
            //     case 3: return “triangle”; break;
            //     // etc
            //     default: return “unknown”;
            // }

            return "";
        }
        #endregion

        #region Form Setup

        public Form1()
        {
            InitializeComponent();
        }

        // When form loads, get paths of all files in test_images folder and store
        // in String array and setup GUI with first file in the folder
        private void Form1_Load(object sender, EventArgs e)
        {
            filePaths = Directory.GetFiles(relPath);                // store paths of a files in resources folder

            if (filePaths.Length == 0)                              // if no files in resources folder, display message
            {
                imgImage.Image = null;
                labelFileName.Text = "No Files";
                txtOutput.Text = relPath + " folder is empty!";
                return;
            }

            try
            {                                                       // set up GUI with first file in resources folder
                curFile = 0;
                labelFileName.Text = Path.GetFileName(filePaths[curFile]);
                img = new Image<Rgb, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                findShape(img);
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type";
            }
        }
        #endregion

        #region Button Click Events

        // Attempts to retrieve image from specified file name in GUI.
        // File must be in test_images folder.
        private void btnGetImage_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            if (txtFileName.Text.Equals(""))
            {
                labelFileName.Text = "???";
                txtOutput.Text = "Enter a file name";
                imgImage.Image = null;
                txtFileName.Clear();
                return;
            }

            try
            {
                img = new Image<Rgb, Byte>(relPath + "\\" + txtFileName.Text);
                imgImage.Image = img;
                findShape(img);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    if (filePaths[i].Equals(txtFileName.Text))
                    {
                        curFile = i;
                        break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                labelFileName.Text = txtFileName.Text;
                txtOutput.Text = "File not found";
                imgImage.Image = null;
            }
            catch (System.ArgumentException)
            {
                labelFileName.Text = txtFileName.Text;
                txtOutput.Text = "Unexpected file type";
                imgImage.Image = null;
            }

            txtFileName.Clear();
        }

        // When next button clicked, goes to next file in test_images folder
        // If currently on last file, will go to the first file in the folder
        private void btnNextImg_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            curFile = curFile == filePaths.Length-1 ? 0 : curFile+1;             // if on last file, go to first

            try
            {                                                                    // try to store and display image
                labelFileName.Text = Path.GetFileName(filePaths[curFile]);
                img = new Image<Rgb, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                findShape(img);
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type";
                imgImage.Image = null;
            }
        }

        // When previous button clicked, goes to previous file in test_images folder
        // If currently on first file, will go to last file in folder
        private void btnPrevImg_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();

            curFile = curFile == 0 ? filePaths.Length-1 : curFile-1;        // if on first file, go to last

            try
            {                                                               // try to store and display image
                labelFileName.Text = Path.GetFileName(filePaths[curFile]);
                img = new Image<Rgb, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                findShape(img);
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type";
                imgImage.Image = null;
            }
        }

        #endregion

        public struct Point
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
