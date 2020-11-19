using System;
using System.Threading;
using System.Collections.Generic;

namespace GUIPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI gui = new GUI();
            gui.AddRow(2);
            IWindow playerWindow = new BasicWindow();
            IWindow npcWindow = new BasicWindow();
            IWindow secondPlayerWindow = new BasicWindow();
            IWindow secondNpcWindow = new BasicWindow();
            gui.OpenWindows(new List<IWindow>() 
                    {
                    playerWindow,
                    npcWindow
                    }, 0);
            gui.OpenWindows(new List<IWindow>() 
                    {
                    secondPlayerWindow,
                    secondNpcWindow
                    }, 1);
            gui.Refresh();
            playerWindow.Print("I'll go over the colors one more time that we use: Titanium white, Thalo green, Prussian blue, Van Dyke brown, Alizarin crimson, Sap green, Cad yellow, and Permanent red. There isn't a rule. You just practice and find out which way works best for you. Just think about these things in your mind - then bring them into your world. Work on one thing at a time. Don't get carried away - we have plenty of time.  This is unplanned it really just happens. Let that brush dance around there and play. Son of a gun. From all of us here, I want to wish you happy painting and God bless, my friends. You can create the world you want to see and be a part of. You have that power. Let's make a happy little mountain now.  They say everything looks better with odd numbers of things. But sometimes I put even numbers—just to upset the critics. A big strong tree needs big strong roots. Making all those little fluffies that live in the clouds. It's life. It's interesting. It's fun. Put light against light - you have nothing. Put dark against dark - you have nothing. It's the contrast of light and dark that each give the other one meaning. You have to make these big decisions.  Look at them little rascals. You have freedom here. The only guide is your heart. Anytime you learn something your time and energy are not wasted. You can get away with a lot. Everyone needs a friend. Friends are the most valuable things in the world. I'm gonna add just a tiny little amount of Prussian Blue.");
            npcWindow.Print("It's you I like, It's not the things you wear, It's not the way you do your hair But it's you I like The way you are right now, The way down deep inside you Not the things that hide you, Not your toys They're just beside you.But it's you I like Every part of you.  Your skin, your eyes, your feelings Whether old or new.  I hope that you'll remember Even when you're feeling blue That it's you I like, It's you yourself It's you.  It's you I like.");
            //Console.WriteLine($"The original buffer size is {GUI.OrigBufferWidth} x {GUI.OrigBufferHeight}");
            //Console.WriteLine($"playerWindow starts at {playerWindow.BufferLeft}, and npcWindow starts at {npcWindow.BufferLeft}");
            //Console.WriteLine($"Row 1 has {GUI.Rows[0].Windows.Count} windows");
            //Console.CursorTop = 5;
            //Console.CursorLeft = 28;
            Console.ReadLine();
        }
    }
    public class GUI
    {
        public static int OrigBufferWidth { get; set; }
        public static int OrigBufferHeight { get; set; }
        public static int GutterSize { get; set; } = 2;
        public static int TotalRowGutterSize => GUI.GutterSize * ( Rows.Count + 1 );
        public static int RowHeight => ( GUI.OrigBufferHeight - GUI.TotalRowGutterSize ) / GUI.Rows.Count;
        public static List<Row> Rows { get; set; }
        public GUI()
        {
            GUI.OrigBufferWidth = Console.BufferWidth;
            GUI.OrigBufferHeight = Console.BufferHeight;
            Rows = new List<Row>();
        }
        public void AddRow(int num)
        {
            for ( int i = 0; i < num; i ++ )
            {
                Rows.Add(new Row());
            }
        }
        public void OpenWindow(IWindow window, int rowIndex)
        {
            Rows[rowIndex].OpenWindow(window);
        }
        public void OpenWindows(List<IWindow> windows, int rowIndex)
        {
            Rows[rowIndex].OpenWindows(windows);
        }
        public void CloseWindow(IWindow window)
        {
            foreach ( IRow row in Rows )
            {
                if ( row.Windows.Contains(window) )
                {
                    row.Windows.Remove(window);
                    row.DistributeWindows();
                    this.Refresh();
                }
            }
        }
        public void Refresh()
        {
            int i = 0;
            Console.Clear();
            foreach (Row row in Rows)
            {
                row.RowTop = ( GUI.RowHeight * i ) + GUI.GutterSize;
                row.DistributeWindows();
                i++;
            }
        }
    }
    public class Row : IRow
    {
        public int RowTop { get; set; }
        public int TotalWindowGutterSize => GUI.GutterSize * ( this.Windows.Count + 1 );
        public int WindowWidth => (GUI.OrigBufferWidth - this.TotalWindowGutterSize) / this.Windows.Count;
        public List<IWindow> Windows { get; set; } = new List<IWindow>();
        public void OpenWindow(IWindow window)
        {
            Windows.Add(window);
        }
        public void OpenWindows(List<IWindow> windows)
        {
            Windows.AddRange(windows);
        }
        public void DistributeWindows()
        {
            int i = 0;
            BufSettings newBuffer = new BufSettings();
            foreach ( IWindow window in Windows )
            {
                newBuffer.Width = this.WindowWidth;
                newBuffer.Height = GUI.RowHeight;
                newBuffer.Top = this.RowTop;
                newBuffer.Left = ( this.WindowWidth * i ) + ( GUI.GutterSize * i ) + GUI.GutterSize;
                window.Redraw(newBuffer);
                //Console.WriteLine($"Window {i}: Cursor is at {window.BufferLeft} x {window.BufferTop}... Window size is {window.BufferWidth} x {window.BufferHeight}");
                i++;
            }
        }
        public void CloseWindow(IWindow window)
        {
            Windows.Remove(window);
        }
    }
    public interface IRow
    {
        List<IWindow> Windows { get; }
        void OpenWindow(IWindow window);
        void DistributeWindows();
        void CloseWindow(IWindow window);
    }
    public class BasicWindow : IWindow
    {
        public int BufferWidth { get; set; }
        public int BufferHeight { get; set; }
        public int BufferTop { get; set; }
        public int BufferLeft { get; set; }
        public (int x, int y) Address { get; set; }
        public GUI GUIContext { get; set; }
        public Border Border { get; set; } 
        public BasicWindow()
        {
            this.Border = new Border(this);
        }
        public void Activate()
        {
            Console.SetCursorPosition(this.BufferTop, this.BufferLeft);
            Console.BufferWidth = this.BufferWidth;
            Console.BufferHeight = this.BufferHeight;
        }
        public void Redraw(BufSettings dim)
        {
            this.BufferWidth = dim.Width;
            this.BufferHeight = dim.Height;
            this.BufferTop = dim.Top;
            this.BufferLeft = dim.Left;
            //Console.WriteLine("Redrawing windows...");
            this.Border.Draw();
        }
        public void Close()
        {
            GUIContext.CloseWindow(this);
        }
        public void Print(string message)
        {
            //this.Activate();
            if ( message.Length < this.BufferWidth )
            {
                Console.SetCursorPosition(this.BufferLeft, this.BufferTop);
                Console.WriteLine(message);
            }
            else
            {
                IEnumerable<string> messageLines = message.Split(this.BufferWidth);
                int i = 0;
                foreach ( string messageLine in messageLines )
                {
                    Console.SetCursorPosition(this.BufferLeft, this.BufferTop + i);
                    Console.WriteLine(messageLine);
                    i ++;
                }
            }
        }
    }
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
                if ((rowIndex <= GUI.GutterSize) || (rowIndex >= (this.Window.BufferHeight + GUI.GutterSize) - 1))
                {
                    Console.WriteLine(fullBorder);
                    Thread.Sleep(50);

                }
                else
                {
                    Console.Write(side);
                    Console.SetCursorPosition(this.BufferLeft + GUI.GutterSize + this.Window.BufferWidth , this.BufferTop + rowIndex);
                    Console.Write(side);
                    Thread.Sleep(50);
                }
            }
            Console.ResetColor();
        }
    }
    public class BufSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
    }
    public interface IWindow
    {
        int BufferWidth { get; set; }
        int BufferHeight { get; set; }
        int BufferTop { get; set; }
        int BufferLeft { get; set; }
        GUI GUIContext { get; set; }
        void Activate();
        void Redraw(BufSettings dim);
        void Close();
        void Print(string message);
    }
    public static class Extensions
    {
        public static IEnumerable<string> Split(this string str, int maxLength)
        {
            if (String.IsNullOrEmpty(str) || maxLength < 1)
            {
                throw new ArgumentException();
            }
            int index = 0;
            while ( index + maxLength < str.Length )
            {
                yield return str.Substring(index, maxLength);
                index += maxLength;
            }
            yield return str.Substring(index);
        }
    }
}
