using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollisCAsciiArtLib.Controller
{
    public class ImageFileIO
    {
        public static Image ImageFromFile(string fileName)
        {
            Image img = null;
            try
            {
                img = Image.FromFile(fileName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Invalid File");
                Console.WriteLine(e.Message);
            }

            return img;
        }

        public static bool saveArtToFile(string art, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(art);
            }

            return true;
        }
    }    
}
