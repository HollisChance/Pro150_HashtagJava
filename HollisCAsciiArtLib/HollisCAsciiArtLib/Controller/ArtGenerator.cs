using HollisCAsciiArtLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollisCAsciiArtLib.Controller
{
    public class ArtGenerator
    {
        private ArtOptions defaultOptions = new ArtOptions { DarkChar = "@", MedChar = "/s", LightChar = "!", LightValue = -1, DarkValue = 11500000 };
        public string MakeArt(Image img, ArtOptions options = null)
        {
            if (options == null)
            {
                options = defaultOptions;
            }

            string artString = "";
            Image newImg = ImageFormatter.scaleImage(img, .35, .35);

            Bitmap bmp = new Bitmap(ImageFormatter.FormatForAscii(newImg));

            //Console.WindowWidth = bmp.Width + 10;

            //Bitmap bmp = new Bitmap(newImg);
            
            StringBuilder sb = new StringBuilder();

            for (int h = 1; h < bmp.Height - 1; h++)
            {
                Console.WriteLine();
                for (int w = 1; w < bmp.Width - 1; w++)
                {
                    //Console.WriteLine(bmp.GetPixel(w, h).ToArgb());
                    int x = bmp.GetPixel(w, h).ToArgb();
                    if (x <= -1 && x > options.LightValue) // default: 

                    {
                        sb.Append(options.LightChar);
                    }
                    else if (x >= -16777216 && x < -options.DarkValue) // default: -11500000
                    {
                        sb.Append(options.DarkChar);
                    }
                    else
                    {
                        sb.Append(options.MedChar);
                    }
                }
                sb.Append("\n");
            }
            artString = sb.ToString();
            return artString;
        }
    }
}
