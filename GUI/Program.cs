using System;
using System.Collections.Generic;

namespace GUIPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI gui = new GUI();
            gui.AddRow(1);
            IWindow playerWindow = new BasicWindow();
            IWindow npcWindow = new BasicWindow();
            gui.OpenWindows(new List<IWindow>() {
                    playerWindow,
                    npcWindow
                    }, 0);
            playerWindow.Print("See that guy over there? We all call him 'Dumbass'");
            npcWindow.Print("Hello, there! My name is Chris, but most people call me 'Hey dumbass!!'");
            //Console.WriteLine($"The original buffer size is {GUI.OrigBufferWidth} x {GUI.OrigBufferHeight}");
            //Console.WriteLine($"playerWindow starts at {playerWindow.BufferLeft}, and npcWindow starts at {npcWindow.BufferLeft}");
            //Console.WriteLine($"Row 1 has {GUI.Rows[0].Windows.Count} windows");
            //Console.CursorTop = 5;
            //Console.CursorLeft = 28;
        }
    }
    public class GUI
    {
        public static int OrigBufferWidth { get; set; }
        public static int OrigBufferHeight { get; set; }
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
            this.Refresh();
        }
        public void OpenWindows(List<IWindow> windows, int rowIndex)
        {
            Rows[rowIndex].OpenWindows(windows);
            this.Refresh();
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
            foreach (Row row in Rows)
            {
                row.RowTop = (OrigBufferHeight / Rows.Count) * i;
                row.DistributeWindows();
                Console.WriteLine($"Row {i} distributed!");
                i++;
            }
            Console.Clear();
        }
    }
    public class Row
    {
        public int RowTop { get; set; }
        public List<IWindow> Windows { get; set; }
        public Row()
        {
            Windows = new List<IWindow>();
        }
        public void OpenWindow(IWindow window)
        {
            Windows.Add(window);
            this.DistributeWindows();
        }
        public void OpenWindows(List<IWindow> windows)
        {
            Windows.AddRange(windows);
            this.DistributeWindows();
        }
        public void DistributeWindows()
        {
            int i = 0;
            foreach ( IWindow window in Windows )
            {
                window.BufferWidth = GUI.OrigBufferWidth / this.Windows.Count;
                window.BufferHeight = GUI.OrigBufferHeight / GUI.Rows.Count;
                window.BufferTop = this.RowTop;
                window.BufferLeft = (GUI.OrigBufferWidth / Windows.Count) * i;
                Console.WriteLine($"Window {i}: Cursor is at {window.BufferLeft} x {window.BufferTop}... Window size is {window.BufferWidth} x {window.BufferHeight}");
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
        public void Activate()
        {
            Console.SetCursorPosition(this.BufferTop, this.BufferLeft);
            Console.BufferWidth = this.BufferWidth;
            Console.BufferHeight = this.BufferHeight;
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
    public interface IWindow
    {
        int BufferWidth { get; set; }
        int BufferHeight { get; set; }
        int BufferTop { get; set; }
        int BufferLeft { get; set; }
        GUI GUIContext { get; set; }
        void Activate();
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
