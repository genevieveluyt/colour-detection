using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Polygon_Detection.src
{
    /// <summary>
    /// Storage class for the core of an images data, including its ID, geolocation,
    /// byte data, and more.
    /// </summary>
    public class ImageData
    {
        #region Constructor
        /// <summary>
        /// Takes parameters related to an instance of an image
        /// and populates all of the properties.
        /// </summary>
        /// <param name="ImgID"></param>
        /// <param name="ImgPath"></param>
        public ImageData(uint ImgID, string ImgPath)
        {
            ID = ImgID;
            Path = ImgPath;
            Bitmap = null;
            Image = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// This is the unique ID the image was given within the Data Center. 
        /// </summary>
        public uint ID { get; private set; }

        /// <summary>
        /// The path on the Datacenter to the original image.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// The original data of the image.
        /// </summary>
        public BitmapSource Bitmap { get; set; }

        public Image<Bgra, Byte> Image;

        //public Aero.Utils.GimbalTelemetry Telemetry { get; private set; }

        #endregion
    }
}
