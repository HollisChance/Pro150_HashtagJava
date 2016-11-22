using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollisCAsciiArtLib.Model
{
    public class ArtOptions
    {
        private const int maxColorValue = -16777216;
        private const int minColorValue = -1;
        private const int defaultDarkValue = -11500000;
        private const int defaultLightValue = -7500000;

        private int darkColorThreshhold = maxColorValue;
        private int lightColorThreshhold = minColorValue;

        private string darkChar = "#";
        private int darkCounter = 0;
        private string medChar = "!";
        private int medCounter = 0;
        private string lightChar = " ";
        private int lightCounter = 0; 
        
        public int DarkValue
        {
            get { return darkColorThreshhold; }
            set { darkColorThreshhold = value; }
        }

        public int LightValue
        {
            get { return lightColorThreshhold; }
            set { lightColorThreshhold = value; }
        }

        public string LightChar
        {
            get
            {
                string light = lightChar;
                if (lightChar.Count() > 1) // black value
                {
                    light = lightChar.ElementAt(lightCounter).ToString();
                    lightCounter++;
                    if (lightCounter > lightChar.Count() - 1)
                    {
                        lightCounter = 0;
                    }
                }
                return light;
            }
            set { lightChar = value; }
        }


        public string MedChar
        {
            get
            {
                string med = medChar;
                if (medChar.Count() > 1) // black value
                {
                    med = medChar.ElementAt(medCounter).ToString();
                    medCounter++;
                    if (medCounter > medChar.Count() - 1)
                    {
                        medCounter = 0;
                    }
                }
                return med;
            }
            set { medChar = value; }
        }

        public string DarkChar
        {
            get
            {
                string dark = darkChar;
                if (darkChar.Count() > 1) // black value
                {
                    dark = darkChar.ElementAt(darkCounter).ToString();
                    darkCounter++;
                    if (darkCounter > darkChar.Count() - 1)
                    {
                        darkCounter = 0;
                    }
                }
                return dark;
            }
            set { darkChar = value; }
        }


        
    }
}
