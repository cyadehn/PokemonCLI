using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
//using RestSharp;
//using SixLabors.ImageSharp;

namespace ASCIImg
{
    public static partial class ASCIIConverter
    {
        //Pseudocode from https://www.c-sharpcorner.com/article/generating-ascii-art-from-an-image-using-C-Sharp/
        private static string[] _AsciiChars = { "#", "@", "$", "&", "%", "=","+", "*", ":", "-", ".", " " };
        public static string[] _fullSpectrum = { "$", "@", "B", "%", "8", "&", "W", "M", "#", "*", "o", "a", "h", "k", "b", "d", "p", "q", "w", "m", "Z", "O", "0", "Q", "L", "C", "J", "U", "Y", "X", "z", "c", "v", "u", "n", "x", "r", "j", "f", "t", "/", @"\", "|", "(", ")", "1", "{", "}", "[", "]", "?", "-", "_", "+", "~", "<", ">", "i", "!", "l", "I", ";", ":", ",", @"\", "”", "^", @"\", "`", @"\", @"’", ".", " "};
        public static string[] _medSpectrum = { "#", "$", "@", "%", "8", "&", "*", "|", "?", "-", "_", "+", "~", "!", ";", ":", ",", "”", "^", "`", @"’", ".", " "};
        private static string CallingDirectory => new System.Uri(Assembly.GetCallingAssembly().Location).AbsolutePath.Split("/bin")[0];
        private static string OutputPath = Path.Combine(ASCIIConverter.CallingDirectory,"output/medOutput.txt");
        private static string txtPath  => Path.Combine(ASCIIConverter.CallingDirectory,"images/132.png");
        private static List<string> _Content = new List<string>() { "eenie", "meenie", "miney", "moe"  };
        public static void Convert()
        {
            //Load the Image from the specified path
            Console.WriteLine(txtPath);
            Bitmap image = new Bitmap(txtPath, true);           
            //
            //Resize the image...
            //I've used a trackBar to emulate Zoom In / Zoom Out feature
            //This value sets the WIDTH, number of characters, of the text image
            image = GetReSizedImage(image,150);
            //
            //Convert the resized image into ASCII
            _Content = ConvertToAscii(image);
            //
            ASCIIConverter.WriteContentToFile();
        } 
        private static Bitmap GetReSizedImage(Bitmap inputBitmap, int asciiWidth )
        {           
            int asciiHeight=0;
            //Calculate the new Height of the image from its width
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);
            //Create a new Bitmap and define its resolution
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((Image)result);
            //The interpolation mode produces high quality images
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }
        private static Bitmap CropImage(Bitmap inputBitmap, Rectangle crop)
        {
            Bitmap bmpCrop = inputBitmap.Clone(crop, inputBitmap.PixelFormat);
            return bmpCrop;
        }
        private static List<string> ConvertToAscii(Bitmap image)
        {
            Boolean toggle = false;
            List<string> lines = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    int red;
                    int green;
                    int blue;
                    //Average out the RGB components to find the Gray Color
                    if (pixelColor.A != 0)
                    {
                        red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    }
                    else
                    {
                        red = 255;
                        green = 255;
                        blue = 255;
                    }
                    Color grayColor = Color.FromArgb(red,green,blue);
                    //Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        int index = (grayColor.R * (_AsciiChars.Length - 1)) / 255;
                        sb.Append(_AsciiChars[index]);
                    }
                }
                if (!toggle)
                {
                    lines.Add(sb.ToString());
                    sb.Clear();
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }
            }
            return lines;
        }
        private static List<ColorChar> ConvertToColorAscii(Bitmap image)
        {
            throw new NotImplementedException();
        }
        private static void WriteTextToFile()
        {
        }
        private static void SaveHTMLToFile()
        {
            List<string> html = new List<string>();
            html.Add("<pre>");
            foreach ( string line in _Content )
            {
                html.Add(line.Replace(" ", "&nbsp;") + "<BR>");
            }
            html.Add("</pre>");
            ASCIIConverter.WriteContentToFile(html);
        }
        public static void WriteContentToFile(List<string> lines)
        {
            File.WriteAllLines(ASCIIConverter.OutputPath, lines);
        }
        public static void WriteContentToFile()
        {
            File.WriteAllLines(ASCIIConverter.OutputPath, _Content);
        }
    }
    public struct ColorChar : IEquatable<ColorChar>
    {
        public ColorChar(ConsoleColor color, Char character)
        {
            this.Color = color;
            this.Character = character;
        }
        ConsoleColor Color;
        Char Character;
        public override bool Equals(Object obj)
        {
            if ( obj == null || ! ( this.GetType().Equals(obj.GetType()) ) )
            {
                return false;
            }
            else
            {
                ColorChar cc = (ColorChar) obj;
                return ( this.Color == cc.Color ) && ( this.Character == cc.Character );
            }
        }
        public bool Equals(ColorChar that)
        {
            return ( this.Color == that.Color ) && ( this.Character == that.Character );
        }
        public override int GetHashCode()
        {
            return this.Color.GetHashCode() ^ Character.GetHashCode();
        }
    }
}
