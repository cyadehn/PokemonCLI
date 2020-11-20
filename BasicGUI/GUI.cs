using System;
using System.Collections.Generic;

namespace BasicGUI
{
    public class GUI
    {
        public static int DebugSleepTime { get; set; } = 0;
        public static int OrigBufferWidth { get; set; }
        public static int OrigBufferHeight { get; set; }
        public static int GutterSize { get; set; } = 2;
        public static int TotalRowGutterSize => GUI.GutterSize * ( Rows.Count + 1 );
        public static int RowHeight => ( GUI.OrigBufferHeight - GUI.TotalRowGutterSize ) / GUI.Rows.Count;
        public static IUserInput UserInput { get; set; }
        public static List<Row> Rows { get; set; }
        public GUI()
        {
            GUI.OrigBufferWidth = Console.BufferWidth;
            GUI.OrigBufferHeight = Console.BufferHeight;
            GUI.Rows = new List<Row>();
            GUI.UserInput = new UserInput();
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
        public void CloseAll()
        {
            GUI.Rows = new List<Row>();
            this.AddRow(1);
        }
        public void Refresh()
        {
            int i = 0;
            Console.Clear();
            foreach (Row row in Rows)
            {
                row.RowTop = ( (GUI.GutterSize + GUI.RowHeight) * i ) + GUI.GutterSize;
                row.DistributeWindows();
                i++;
            }
        }
    }
}
