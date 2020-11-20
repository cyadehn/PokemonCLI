using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace PokemonCLI
{
    public static class Tools
    {
        public static Assembly Assembly { get; private set; } = Assembly.GetExecutingAssembly();
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
    }
}
