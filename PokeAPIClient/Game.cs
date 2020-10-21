using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text.Json.Serialization;

namespace PokeAPIClient
{
    public class Game
    {
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }

        public Game()
        {

        }

        public void NewGame()
        {
            Tools.PrintDialogue(Tools.ReadDialogue("introDialogue.txt"));
            PlayerCharacter player1 = new PlayerCharacter();
        }
    }

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
