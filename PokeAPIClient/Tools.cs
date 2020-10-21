using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace PokeAPIClient
{
    public static class Tools
    {
        public static List<string> ReadDialogue(string fileName)
        {
            List<string> dialogue = new List<string>();
            string fileLocation = string.Format("dialogue/{0}", fileName);
            using ( var reader = new StreamReader(fileLocation))
            {
                string line;
                while ( (line = reader.ReadLine()) != null )
                {
                    dialogue.Add(line);
                }
            }
            return dialogue;
        }

        public static void PrintDialogue(List<string> dx)
        {
            foreach ( string line in dx )
            {
                Console.Write(line);
                Thread.Sleep(1000);
                for ( int i = 0; i < line.Length/15; i++ )
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Write("\n\r");
            }
        }
    }
}
