using System;
//using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
//using RestSharp;
//using SixLabors.ImageSharp;

namespace ASCIImg
{
    public static partial class ASCIIConverter
    {
        //Pseudocode from https://www.c-sharpcorner.com/article/generating-ascii-art-from-an-image-using-C-Sharp/
        private static string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };
        private static string txtPath { get; set; } = "images/132.png";
        private static List<string> _Content;
        private static void Convert()
        {
            //Load the Image from the specified path
            Bitmap image = new Bitmap(txtPath, true);           
            //
            //Resize the image...
            //I've used a trackBar to emulate Zoom In / Zoom Out feature
            //This value sets the WIDTH, number of characters, of the text image
            image = GetReSizedImage(image,50);           
            //
            //Convert the resized image into ASCII
            _Content = ConvertToAscii(image);
            //
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
                    //Average out the RGB components to find the Gray Color
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(red,green,blue);
                    //Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
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
        //private static void SaveToFile()
        //{
            //if (saveFileDialog1.FilterIndex == 1)
            //{
                //_Content = _Content.Replace("&nbsp;", " ").Replace("<BR>","\n");
            //}
            //else
            //{
                //_Content = "<pre>" + _Content + "</pre>";
            //}
            //StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            //sw.Write(_Content);
            //sw.Flush();
            //sw.Close();
        //}
    }
}
