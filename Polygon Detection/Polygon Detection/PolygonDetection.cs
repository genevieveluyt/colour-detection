﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_Detection
{
    public static class PolygonDetection
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        struct Point
        {
            public int x, y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        
        static List <Point> points;
        static float straightAngleTolerance = 10; // in degrees

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
