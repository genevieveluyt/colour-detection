using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aero.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Convert Radian to Degrees. 
        /// </summary>
        /// <param name="Radians"></param>
        /// <returns>A float degree from -NaN to NaN (non-normalized).</returns>
        public static float RadiansToDegrees(float Radians)
        {
            return (float)(Radians * (180.00 / Math.PI));
        }

        /// <summary>
        /// Converts an angle in degrees to radians.
        /// </summary>
        /// <param name="degrees">Angle in decimal degrees</param>
        /// <returns>Value in radians.</returns>
        public static float DegreesToRadians(float Degrees)
        {
            return (float)(Degrees * (Math.PI / 180));
        }

        /// <summary>
        /// Converts an angle in radians to degrees.
        /// </summary>
        /// <param name="rads">Angle in radians</param>
        /// <returns>Angle in degrees</returns>
        public static double RadiansToDegrees(double rads)
        {
            return (rads * (180 / Math.PI));
        }
        /// <summary>
        /// Converts an angle in degrees to radians.
        /// </summary>
        /// <param name="degrees">Angle in decimal degrees</param>
        /// <returns>Value in radians.</returns>
        public static double DegreesToRadians(double degrees)
        {
            return (degrees * (Math.PI / 180));
        }
    }
}
