using System;
using System.Threading;

namespace BasicGUI
{
    public class Typewriter
    {
        public WindowWriter Writer { get; set; }
        public Typewriter(WindowWriter writer)
        {
            Writer = writer;
        }
        public void PrintChars(string line)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                    CharacterDelay(c);
                }
                this.Writer.AdvanceLine();
            }
        public void Pause()
        {
            ConsoleKey key;
            do {
                key = Console.ReadKey(true).Key;
                Thread.Sleep(100);
            } while (key != ConsoleKey.Enter);
            this.Writer.Write("\n\r");
        }
        public void PrintPause(int num)
        {
            for ( int i = 0; i < num; i++ )
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
            this.Writer.Write("\n\r");
        }
        public void PrintSubtle(string line)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            this.Writer.Write(line);
            Console.ResetColor();
        }
        private void CharacterDelay(char c)
            {
                int sentenceEnd = 300;
                int commaPause = 99;
                int characterDelay = 15;
                if (c == '.' )
                {
                    Thread.Sleep(sentenceEnd);
                }
                else if ( c == ',' )
                {
                    Thread.Sleep(commaPause);
                }
                else 
                {
                    Thread.Sleep(characterDelay);
                }
            }
    }
}
