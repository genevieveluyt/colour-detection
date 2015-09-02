using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Polygon_Detection.src
{
    public class ColourDetection
    {
        //Local variables for processing values
        public struct CustomHsv
        {
            public double Hue;
            public double Saturation;
            public double Value;

            public CustomHsv(double h, double s, double v)
            {
                Hue = h;
                Saturation = s;
                Value = v;
            }
        }        

        public override string ToString()
        {
            return "ColourDetection";
        }

        public ColourDetection()
        {
            //Make some calls to the configuration storage to get variables. 
            // threshold = ConfigurationStorage.Get("ExampleCVAlgo.threshold");

            //The first word should be the name of the algorithm itself, see ToString() above.
        }

        // returns a string with number of pixels per colour in sorted order
        public string Process(ImageData ImageData)
        {
            //Do not modify the Image or MetaData, they are to be left alone. 
            //If you need a copy, or want to change values, Clone the data.


            //Do some processing on the image. 

            //return some results, the type of which we don't know yet. 

            Image<Bgra, Byte> image = ImageData.Image;

            const int BLACK     = 0;
            const int WHITE     = 1;
            const int RED       = 2;
            const int ORANGE    = 3;
            const int BROWN     = 4;
            const int YELLOW    = 5;
            const int GREEN     = 6;
            const int BLUE      = 7;
            const int PURPLE    = 8;
            const int PINK      = 9;

            int[] colourNames = { BLACK, WHITE, RED, ORANGE, BROWN, YELLOW, GREEN, BLUE, PURPLE, PINK };
            int[] colours = new int[colourNames.Length];

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    CustomHsv pixel = rgbToHsv(image[y, x]);
                    int sat = (int)pixel.Saturation;
                    int val = (int)pixel.Value;
                    
                    // Determine colour of pixel
                    // To pick colour thresholds I used: http://colorizer.org/
                    // and http://i.imgur.com/PKjgfFXm.jpg

                    if (val < 2)
                        colours[BLACK]++;
                    else if (sat < 2 && val > 98)
                        colours[WHITE]++;
                    else if (sat > 10)  // Saturation > 10% is not grey
                    {
                        int hue = (int)pixel.Hue;

                        if (hue < 17)
                        {
                            if (val > 40)
                                colours[RED]++;
                            else
                                colours[BROWN]++;
                        }
                        else if (hue < 45)
                        {
                            if (val > 70)
                                colours[ORANGE]++;
                            else
                                colours[BROWN]++;
                        }
                        else if (hue < 82)
                        {
                            if (val > 50)
                                colours[YELLOW]++;
                            else
                                colours[BROWN]++;
                        }
                        else if (hue < 150)
                            colours[GREEN]++;
                        else if (hue < 250)
                            colours[BLUE]++;
                        else if (hue < 290)
                            colours[PURPLE]++;
                        else if (hue < 345)
                        {
                            if (val > 70)
                                colours[PINK]++;
                            else
                                colours[PURPLE]++;
                        }
                        else
                            colours[RED]++;
                    }
                }
            }
            // To get a list of the number of pixels of each colour in descending order use:
            return reportAllColours(colourNames, colours);
            // To get the dominant colour (most pixels are in this colour) use:
            //return getColour(maxColour(colourNames, colours));
        }


        public void Dispose()
        {
            //De-allocate anything that is not managed already. 
        }


        // Finds the colour of which the max amount of pixels are present
        // excluding white and black.
        // Returns the numerical value of that colour (as defined by class constants)
        private int maxColour(int[] colourNames, int[] colours)
        {
            int index = 2;  // 0 and 1 are black and white respectively
            int max = colours[index];

            for (int i = 3; i < colours.Length; i++)
            {
                if (colours[i] > max)
                {
                    max = colours[i];
                    index = i;
                }
            }
            return colourNames[index];
        }

        // returns the string value of a colour (as defined by constants in Process())
        private string getColour(int col)
        {
            string colour = null;
            switch (col)
            {
                case 0: colour = "Black"; break;
                case 1: colour = "White"; break;
                case 2: colour = "Red"; break;
                case 3: colour = "Orange"; break;
                case 4: colour = "Brown"; break;
                case 5: colour = "Yellow"; break;
                case 6: colour = "Green"; break;
                case 7: colour = "Blue"; break;
                case 8: colour = "Purple"; break;
                case 9: colour = "Pink"; break;
            }
            return colour;
        }

        // Sorts the list of colours and their names in order of most to least
        // number of pixels in that colour.
        // Returns a string with results.
        private string reportAllColours(int[] colourNames, int[] colours)
        {

            // Sorts the colours
            // To include Black and White, use:
            Array.Sort(colours, colourNames);
            // To exclude Black and White, use:
            //Array.Sort(colour, colourKeys, 2, colour.Length-2);

            string output = "";

            // Goes through amount of pixels of each colour in reverse order
            // (greatest to least)
            // To include Black and White, use:
            for (int i = colours.Length - 1; i >= 0; i--)
            // To exclude Black and White, use:
            //for (int i = colour.Length - 1; i >= 2; i--)
            {
                output += getColour(colourNames[i]) + " pixels: " + colours[i] + Environment.NewLine;
            }

            return output;
        }

        // Emgu Hsv has hue, saturation and value ranges going up to 180, 255 and 255 respectively.
        // Make a custom Hsv structure with ranges 360(degrees), 100(%) and 100(%) which is used by
        // most graphical representations of Hsv.
        // Source of formulas: http://www.rapidtables.com/convert/color/rgb-to-hsv.htm
        public static CustomHsv rgbToHsv(Bgra pixel)
        {
            int red = (int)pixel.Red;
            int green = (int)pixel.Green;
            int blue = (int)pixel.Blue;

            int min = Math.Min(Math.Min(red, green), blue);
            int max = Math.Max(Math.Max(red, green), blue);

            float hue = 0f;
            if (max == min)
            {
                hue = 0;
            }
            else if (max == red)
            {
                hue = (float)(green - blue) / (max - min);

            }
            else if (max == green)
            {
                hue = 2f + (float)(blue - red) / (max - min);
            }
            else
            {
                hue = 4f + (float)(red - green) / (max - min);
            }

            hue = hue * 60;
            if (hue < 0) hue = hue + 360;

            int saturation = (int)Math.Round( max == 0 ? 0f : (float)(max - min) / max * 100);  // if max == 0, colour is black
            int value = (int)Math.Round((float)max / 255 * 100);

            return new CustomHsv((int)Math.Round(hue), saturation, value);
        }
    }
}
