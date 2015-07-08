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


namespace Polygon_Detection.src
{
    public partial class GUI : Form
    {
        #region Process Image

        Image<Bgra, Byte> img;

        // use this as main, right now it runs every time an image
        // is displayed in the GUI
        public void processImage(Image<Bgra, Byte> image)
        {
            ImageData data = new ImageData(1234, "foo");
            data.Image = image;

            ColourDetection detect = new ColourDetection();
            txtOutput.Text = detect.Process(data);

            //txtOutput.AppendText(Environment.NewLine + rgbToHsv(new Rgb(100, 20, 10)).ToString());

            imgImage.Image = image;
        }

        #endregion

        #region Old Corner Detection

        //List<Point> points;
        float straightAngleTolerance = 10;      // in degrees

        /*points = getPoints(image);
        points = getOuterPoints(points); drawCircles(image, points, imgImage);
        points = removeStraightAngles(points);

        if (isShape(points))
        {
            if (!txtOutput.Text.Equals(""))                 // if textbox is not empty, insert new line first
                txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText(determineShape(points));
        }
        else
        {
            if (!txtOutput.Text.Equals(""))
                txtOutput.AppendText(Environment.NewLine);
            txtOutput.AppendText("No shape found");
        }*/

        /* Attempts to locate all corners in an image
         * @return List<Point> list of coordinates
         */
        public List<Point> getPoints(Image<Rgb, Byte> image) {

            List<Point> points = new List<Point>();

            // raw corner strength image (must be 32-bit float)
            Image<Gray, float> m_CornerImage = null;

            // inverted thresholded corner strengths (for display)
            Image<Gray, Byte> m_ThresholdImage = null;
            
            Image<Gray, Byte> m_SourceImage = new Image<Gray, byte>(filePaths[curFile]);
            
            // create corner strength image and do Harris
            m_CornerImage = new Image<Gray, float>(m_SourceImage.Size);
            CvInvoke.cvCornerHarris(m_SourceImage, m_CornerImage, 3, 3, 0.01);

            // create and show inverted threshold image
            m_ThresholdImage = new Image<Gray, Byte>(m_SourceImage.Size);
            CvInvoke.cvThreshold(m_CornerImage, m_ThresholdImage, 0.0001,
                255.0, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY_INV);

            // Looking for maxema
            const int MASK = 8;     // radius of circles used to cover corner harris output to prevent 
                                    // multiple detections of the same corner
            const double MAX_INTENSITY = 0;
            for (int x = 0; x < m_ThresholdImage.Width; x++)
            {
                for (int y = 0; y < m_ThresholdImage.Height; y++)
                {
                    Gray imagenP = m_ThresholdImage[y,x];
                    if (imagenP.Intensity == MAX_INTENSITY)
                    {
                        Point p = new Point(x, y);
                        points.Add(p);

                        // cover up points close to point so they won't be detected                   
                        CircleF circle = new CircleF(p, MASK);
                        m_ThresholdImage.Draw(circle, new Gray(255), -1);
                    }
                }
            }

            return points;
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

            return points;
        }

        /* If angle between any three consecutive points is close to 180
         * (by margin of straightAngleTolerance), removes middle point
         * @param List<Point> list of points that make outline of shape
         *      in (counter)clockwise order
         * @return List<Point> list of points identical to list passed in
         *      excluding those in the middle of straight angles
         */
        public List<Point> removeStraightAngles(List<Point> points) {
            
            if (points.Count < 4)
                return points;
            
            Point a, b, c;

            /// b is the point that will be removed if a-b-c is a straight angle so start
            /// with b at index 0
            a = points.ElementAt(points.Count-1);
            b = points.ElementAt(0);
            c = points.ElementAt(1);

            // txtOutput.AppendText("point a:" + a + " b:" + b + " c:" + c + Environment.NewLine);
            
            int angle;

            for (int i = 2; i < points.Count; i++)
            {
                angle = (int)getSmallestAngle(a, b, c);

                // txtOutput.AppendText("angle: " + angle + Environment.NewLine);
                
                if (angle < 180 + straightAngleTolerance && angle > 180 - straightAngleTolerance)
                {
                    // txtOutput.AppendText("Remove " + b + Environment.NewLine);

                    i--;
                    points.Remove(b);
                    b = c;
                    c = points.ElementAt(i);
                }
                else
                {
                    a = b;
                    b = c;
                    c = points.ElementAt(i);
                }
                //txtOutput.AppendText(Environment.NewLine);
                //txtOutput.AppendText("point a:" + a + " b:" + b + " c:" + c + Environment.NewLine);
            }

            /// The loop ends with c at the last index and b second-to-last.
            /// Wrap c around to index 0 to check if point at last index should be removed.
            a = b;
            b = c;
            c = points.ElementAt(0);
            angle = (int)getSmallestAngle(a, b, c);

            if (angle < 180 + straightAngleTolerance && angle > 180 - straightAngleTolerance)
            {
                // txtOutput.AppendText("Remove " + b + Environment.NewLine);
                points.Remove(b);
            }

            return points;
        }

        /* Identifies the smallest angle between lines a-b and b-c in degrees
         * ie. if 90 degrees and 270 degrees are possible, will return 90
         * @return double smallest angle in degrees
         */
        public double getSmallestAngle(Point a, Point b, Point c) {

            Point A = new Point(a.X - b.X, a.Y - b.Y);      // line a-b
            Point B = new Point(c.X - b.X, c.Y - b.Y);      // line b-c
            
            double angle = Math.Acos(vectorDotProduct(A, B) / (vectorMagnitude(A) * vectorMagnitude(B)));
            angle *= (180.00 / Math.PI);                    // convert from radians to degrees
            
            return angle;
        }

        // Calculates dot product of two 2D vectors
        public double vectorDotProduct(Point a, Point b)
        {
            return (a.X * b.X + a.Y * b.Y);
        }

        // Calculates magnitude of a 2D vector
        public double vectorMagnitude(Point p)
        {
            return Math.Sqrt(vectorDotProduct(p, p));
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

        /*
         * Draws circles around the points on the given image
         */
        public void drawCircles(Image<Rgb, Byte> image, List<Point> points, ImageBox imgBox)
        {
            foreach (Point point in points)
            {
                // txtOutput.AppendText(point.X + " " + point.Y + Environment.NewLine);
                CvInvoke.cvCircle(image.Ptr, 
                                  point, 
                                  4,
                                  new MCvScalar(), 
                                  1, 
                                  Emgu.CV.CvEnum.LINE_TYPE.CV_AA,
                                  0);
            }
            imgBox.Image = image;   
        }

        #endregion

        #region Form Setup

        String relPath = "..\\..\\test_images"; // relative path location of test files
        String[] filePaths;                     // filenames of files in folder with files
        int curFile;                            // index of file currently displayed in filePaths array

        public GUI()
        {
            InitializeComponent();
        }

        // When form loads, get paths of all files in test_images folder and store
        // in String array and setup GUI with first file in the folder
        private void Form1_Load(object sender, EventArgs e)
        {
            filePaths = Directory.GetFiles(relPath);                // store paths of test files in appropriate folder

            if (filePaths.Length == 0)                              // if no files in folder, display message
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
                img = new Image<Bgra, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                processImage(img);
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
                labelFileName.Text = txtFileName.Text;
                img = new Image<Bgra, Byte>(relPath + "\\" + txtFileName.Text);
                imgImage.Image = img;
                processImage(img);
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
                txtOutput.Text = "File not found";
                imgImage.Image = null;
            }
            catch (ArgumentException)
            {
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
                img = new Image<Bgra, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                processImage(img);
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
                img = new Image<Bgra, Byte>(filePaths[curFile]);
                imgImage.Image = img;
                processImage(img);
            }
            catch (System.ArgumentException)
            {
                txtOutput.Text = "Unexpected file type";
                imgImage.Image = null;
            }
        }

        #endregion

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
