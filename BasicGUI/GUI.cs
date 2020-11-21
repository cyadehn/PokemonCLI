using System;
using System.Reflection;
using System.Collections.Generic;

namespace BasicGUI
{
    public class GUI
    {
        public static int DebugSleepTime { get; set; } = 50;
        public static int OrigBufferWidth { get; set; }
        public static int OrigBufferHeight { get; set; }
        public static int GutterSize { get; set; } = 2;
        public static int TotalRowGutterSize => GUI.GutterSize * ( Rows.Count + 1 );
        public static int RowHeight => ( GUI.OrigBufferHeight - GUI.TotalRowGutterSize ) / GUI.Rows.Count;
        public static IUserInput UserInput { get; set; }
        public static List<Row> Rows { get; set; }
        public bool TitleSet { get; set; }
        public GUI()
        {
            GUI.OrigBufferWidth = Console.BufferWidth;
            GUI.OrigBufferHeight = Console.BufferHeight;
            GUI.Rows = new List<Row>();
            GUI.UserInput = new UserInput();
        }
        public void SetTitle(Assembly assembly, string resourceName)
        {
            IWindow title = new TitleWindow(assembly, resourceName);
            this.AddRow(title);
            this.TitleSet = true;
        }
        public void AddRow(List<IWindow> windows)
        {
            Row row = new Row();
            row.OpenWindows(windows);
            GUI.Rows.Add(row);
        }
        public void AddRow(IWindow window)
        {
            Row row = new Row();
            row.OpenWindow(window);
            GUI.Rows.Add(row);
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
            if (this.TitleSet == false)
            {
                GUI.Rows = new List<Row>();
            }
            else
            {
                for ( int i = 1; i < GUI.Rows.Count; i++ )
                {
                    GUI.Rows.RemoveAt(i);
                }
            }
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
