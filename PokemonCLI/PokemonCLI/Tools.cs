using System;
using System.Linq;
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
                }
            public static void Pause()
            {
                ConsoleKey key;
                do {
                    key = Console.ReadKey(true).Key;
                    Thread.Sleep(100);
                } while (key != ConsoleKey.Enter);
                Console.Write("\n\r");
            }
            public static void PrintPause(int num)
            {
                for ( int i = 0; i < num; i++ )
                {
                    Console.Write(".");
                    Thread.Sleep(300);
                }
                Console.Write("\n\r");
            }
            public static void PrintSubtle(string line)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(line);
                Console.ResetColor();
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
        public static class GUI
        {
            public static string ComboBox(List<string> options)
            {
                int width = GetLongestStringLength(options);
                int origRow = Console.CursorTop;
                int origCol = Console.CursorLeft;
                // print box
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(new string(' ', width));
                // reset to beginning position
                Console.SetCursorPosition(origCol, origRow);
                // on down/up arrow, increment the list of strings and print exactly in the middle using the width variable
                // on "enter", set current list item to variable and reset color
                int i = 0;
                string option = options.ElementAt(i);
                while (true)
                {
                    PrintCentered(origCol, origRow, width, option);
                    ConsoleKey key = Console.ReadKey().Key;
                    if ( key == ConsoleKey.Enter )
                    {
                        Console.ResetColor();
                        Console.Write("\n\r");
                        return option;
                    }
                    else if ( key == ConsoleKey.UpArrow )
                    {
                        (int index, string option) decrementTuple = DecrementOption(i, options);
                        option = decrementTuple.option;
                        i = decrementTuple.index;
                    }
                    else if ( key == ConsoleKey.DownArrow )
                    {
                        (int index, string option) incrementTuple = IncrementOption(i, options);
                        option = incrementTuple.option;
                        i = incrementTuple.index;
                    }
                }
            }
            private static (int index, string option) DecrementOption(int i, List<string> options)
            {
                (int index, string option) output = (i, "");
                if ( output.index > 0)
                {
                    output.index--;
                }
                else
                {
                    output.index = options.Count - 1;
                }
                output.option = options.ElementAt(output.index);
                return output;
            }
            private static (int index, string option) IncrementOption(int i, List<string> options)
            {
                (int index, string option) output = (i,"");
                if ( output.index < (options.Count - 1))
                {
                    output.index++;
                }
                else
                {
                    output.index = 0;
                }
                output.option = options.ElementAt(output.index);
                return output;
            }
            private static int GetLongestStringLength(List<string> input)
            {
                int output = 0;
                List<string> orderedList = input.OrderBy(s => s.Length).ToList();
                output = orderedList.LastOrDefault().Length;
                return output;
            }
            private static void PrintCentered(int col, int row, int width, string input)
            {
                int strLength = input.Length;
                int marginSize = (width - strLength)/2;
                string option;
                string margin = new string(' ', marginSize);
                option = margin + input + margin;
                Console.Write(new string(' ', width));
                Console.SetCursorPosition(col, row);
                Console.Write(option);
                Console.SetCursorPosition(col, row);
            }
        }
        public static void PrintDialogue(List<string> dx)
        {
            Typewriter.PrintSubtle("Press 'Enter' to continue...");
            foreach ( string line in dx )
            {
                Typewriter.PrintChars(line);
                Typewriter.Pause();
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
        public static void PrintLoadingLine(List<string> text)
        {
            Console.Write("loading...");
            Typewriter.Pause();
        }
    }
    public interface IUserInput
    {
        string GetUserInput(string prompt);
        string GetUserInput();
    }
}
