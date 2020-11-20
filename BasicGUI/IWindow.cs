using System.Collections.Generic;

namespace BasicGUI
{
    public interface IWindow
    {
        int BufferWidth { get; set; }
        int BufferHeight { get; set; }
        int BufferTop { get; set; }
        int BufferLeft { get; set; }
        int LastLine { get; }
        GUI GUIContext { get; set; }
        Border Border { get; set; }
        WindowWriter Writer { get; set; }
        void Activate();
        void Redraw(BufSettings dim);
        void Close();
        void Print(string message);
        void PrintLines(List<string> messages);
    }
}
