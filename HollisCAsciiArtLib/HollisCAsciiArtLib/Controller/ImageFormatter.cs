using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollisCAsciiArtLib.Controller
{
    public class ImageFormatter
    {
        public static Image FormatForAscii(Image image)
        {
            Image formatted = new Bitmap(image, width: image.Width, height: (image.Height / 2));
            return formatted;            
        }

        public static Image scaleImage(Image image, double heightScale = 1, double widthScale = 1)
        {
            Image scaled = new Bitmap(image, height: (int)(image.Height * heightScale), width: (int)(image.Width * widthScale));
            return scaled;
        }
    }
}
