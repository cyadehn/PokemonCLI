using BasicGUI;
using System;
using System.Collections.Generic;

namespace GUIPractice
{
    partial class Program
    {
        static void Main(string[] args)
        {
            GUI gui = new GUI();
            IWindow playerWindow = new BasicWindow();
            IWindow npcWindow = new BasicWindow();
            IWindow secondPlayerWindow = new BasicWindow();
            IWindow secondNpcWindow = new BasicWindow();
            gui.AddRow(new List<IWindow>() 
                    {
                    playerWindow,
                    npcWindow
                    });
            gui.AddRow(new List<IWindow>() 
                    {
                    secondPlayerWindow,
                    secondNpcWindow
                    });
            gui.Refresh();
            playerWindow.Print(TextLibrary["bob-ross-long"]);
            npcWindow.Print(TextLibrary["rogers-short"]);
            //Console.WriteLine($"The original buffer size is {GUI.OrigBufferWidth} x {GUI.OrigBufferHeight}");
            //Console.WriteLine($"playerWindow starts at {playerWindow.BufferLeft}, and npcWindow starts at {npcWindow.BufferLeft}");
            //Console.WriteLine($"Row 1 has {GUI.Rows[0].Windows.Count} windows");
            //Console.CursorTop = 5;
            //Console.CursorLeft = 28;
            Console.ReadLine();
            Console.Clear();
        }
    }
}
