using System.IO;
using System.Collections.Generic;

namespace ASCIImg
{
    public class ASCIImage
    {
        private MemoryStream Stream { get; set; }
        public ASCIImage(MemoryStream stream)
        {
            this.Stream = stream;
        }
        public ASCIImage()
        {

        }
        public MemoryStream GetStream()
        {
            return this.Stream;
        }
        public List<string> GetStringList()
        {
            List<string> lines = new List<string>();
            return lines;
        }
        public void SaveToFile(string directory)
        {

        }
    }
}
