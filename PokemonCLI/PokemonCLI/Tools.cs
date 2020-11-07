using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonCLI
{
    public static class Tools
    {
        // TODO: Implement a class for reading "script" files
        //          1. Scripts.txt files will define lines with different syntax prefixes to determine the action to take
        //                  examples: * = "DXEngine.PrintDialogue()", ACT = "IAction.Start()", X = "DXEngine.Stop()"
        //          2. DXEngine -- define the following methods:
        //                  1. .Init(string fileName, IState current);
        //                  2. .StartPerformance(List<action>);
        //                  3. .ActOn(IAction action);
        //                  4. PrintDialogue(string line);
        //          3. DXEngine function:
        //                  On State start...   call Init(fileName) for the scene
        //                                      DXEngine will read the lines and run commands (using the this object passed in for scene specific actions?)
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
        public static class Typewriter
        {
            public static void WriteDialogue(string line)
                {
                    foreach (char c in line)
                    {
                        Console.Write(c);
                        CharacterDelay(c);
                    }
                    Console.Write("\n\r");
                }
            private static void CharacterDelay(char c)
                {
                    if (c == '.' )
                    {
                        Thread.Sleep(300);
                    }
                    else if ( c == ',' )
                    {
                        Thread.Sleep(99);
                    }
                    else 
                    {
                        Thread.Sleep(15);
                    }
                }
        }
        public static void PrintDialogue(List<string> dx)
        {
            foreach ( string line in dx )
            {
                Typewriter.WriteDialogue(line);
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
    public class UserInput : IUserInput
    {
        public string GetUserInput(string prompt)
        {
            Tools.Typewriter.WriteDialogue(prompt);
            return Console.ReadLine();
        }
    }
    public interface IUserInput
    {
        string GetUserInput(string prompt);
    }
}