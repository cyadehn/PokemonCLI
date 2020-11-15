using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;

namespace PokemonCLI
{
    public static class Tools
    {
        public static Assembly Assembly { get; private set; } = Assembly.GetExecutingAssembly();
        public class UserInput : IUserInput
        {
            public string GetUserInput()
            {
                Console.WriteLine();
                return Console.ReadLine();
            }
            public string GetUserInput(string prompt)
            {
                Tools.Typewriter.PrintChars(prompt);
                return Console.ReadLine();
            }
        }
        public static class Typewriter
        {
            public static void PrintChars(string line)
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
                (int index, string option) output = (i, "");
                if ( output.index > 0)
                {
                    output.index--;
                }
                Console.Write("\n\r");
            }
        }
        public static void PrintToConsole(List<string> text)
        {
            foreach ( string line in text )
            {
                Typewriter.PrintChars(line);
                Console.Write("\n\r");
            }
        }
    }
    public interface IUserInput
    {
        string GetUserInput(string prompt);
        string GetUserInput();
    }
}
