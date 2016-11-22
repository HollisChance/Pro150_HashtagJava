using HollisCAsciiArtLib.Controller;
using HollisCAsciiArtLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsciiLibTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageFileIO Io = new ImageFileIO();
            //Image img = Io.ImageFromFile("Images\\Chrome.png");
            //Image img = Io.ImageFromFile("C:\\Users\\chance\\Documents\\Visual Studio 2015\\ProjectsCourse-Web\\HollisCAsciiArtLib\\AsciiLibTester\\Images\\Chrome.png");
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var iconPath = Path.Combine(outPutDirectory, "Images\\Java_logo.jpg");
            string path = new Uri(iconPath).LocalPath;

            //string path = @"C:\Users\chance\Documents\Visual Studio 2015\ProjectsCourse-Web\HollisCAsciiArtLib\AsciiLibTester\Images\Chrome.png";
            Image img = ImageFileIO.ImageFromFile(path);

            Bitmap bmp = img as Bitmap;

            ArtGenerator gen = new ArtGenerator();
            ArtOptions opt = new ArtOptions { DarkChar = "#JAVA", MedChar = " ", LightChar = " ", LightValue = -1, DarkValue = 11500000 };
            string art = gen.MakeArt(img, opt);

            Console.WriteLine(art);



            ImageFileIO.saveArtToFile(art, @"testFile.txt");
        }
    }
}
