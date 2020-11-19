using System;
using System.Threading;

namespace GUIPractice
{
    public class Border
    {
        public IWindow Window { get; set; }
        public int BufferTop { get; set; }
        public int BufferLeft { get; set; }
        public Border(IWindow window)
        {
            this.Window = window;
        }
        public void Refresh()
        {
            this.BufferTop  = this.Window.BufferTop - GUI.GutterSize;
            this.BufferLeft = this.Window.BufferLeft - GUI.GutterSize;
        }
        public void Draw()
        {
            //Console.WriteLine("Drawing window borders");
            this.Refresh();
            Console.BackgroundColor = ConsoleColor.Blue;
            //Console.WriteLine(this.Window.BufferTop);
            Console.SetCursorPosition(this.BufferLeft, this.BufferTop);
            string fullBorder = new string(' ', (this.Window.BufferWidth + (2 * GUI.GutterSize)));
            string side = new string(' ', GUI.GutterSize);
            for ( int rowIndex = 0; rowIndex < (this.Window.BufferHeight + (GUI.GutterSize * 2) - 1); rowIndex++ )
            {
                Console.SetCursorPosition(this.BufferLeft, this.BufferTop + rowIndex);
                if ((rowIndex < GUI.GutterSize) || (rowIndex > (this.Window.BufferHeight + GUI.GutterSize) - 1))
                {
                    Console.WriteLine(fullBorder);
                    Thread.Sleep(GUI.DebugSleepTime);

                }
                else
                {
                    Console.Write(side);
                    Console.SetCursorPosition(this.BufferLeft + GUI.GutterSize + this.Window.BufferWidth , this.BufferTop + rowIndex);
                    Console.Write(side);
                    Thread.Sleep(GUI.DebugSleepTime);
                }
            }
            Console.ResetColor();
        }
    }
}
