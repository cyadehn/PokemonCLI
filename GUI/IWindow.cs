namespace GUIPractice
{
    public interface IWindow
    {
        int BufferWidth { get; set; }
        int BufferHeight { get; set; }
        int BufferTop { get; set; }
        int BufferLeft { get; set; }
        int LastLine { get; }
        GUI GUIContext { get; set; }
        void Activate();
        void Redraw(BufSettings dim);
        void Close();
        void Print(string message);
    }
}
