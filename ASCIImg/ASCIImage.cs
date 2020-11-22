using System.IO;

namespace ASCIImg
{
    public class ASCIImage
    {
        private MemoryStream Stream { get; set; }
        public ASCIImage(MemoryStream stream)
        {
            this.Stream = stream;
        }
        public MemoryStream GetStream()
        {
            return this.Stream;
        }
        public List<string> GetStringList()
        {

        }
        public void SaveToFile(string directory)
        {

        }
    }
}
