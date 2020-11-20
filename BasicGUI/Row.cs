using System.Collections.Generic;

namespace BasicGUI
{
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
}
