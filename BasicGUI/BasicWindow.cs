using System;
using System.Collections.Generic;

namespace BasicGUI
{
    public class BasicWindow : IWindow
    {
        public int BufferWidth { get; set; }
        public int BufferHeight { get; set; }
        public int BufferTop { get; set; }
        public int BufferLeft { get; set; }
        public int LastLine => this.BufferTop + this.BufferHeight - 1;
        public (int x, int y) Address { get; set; }
        public GUI GUIContext { get; set; }
        public Border Border { get; set; } 
        public WindowWriter Writer { get; set; }
        public BasicWindow()
        {
            this.Border = new Border(this);
            this.Writer = new WindowWriter(this);
        }
        public void Activate()
        {
            Console.SetCursorPosition(this.BufferLeft, this.BufferTop);
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
            this.Writer.ResetPosition();
            this.Border.Draw();
        }
        public void Redraw()
        {
            this.Writer.ResetPosition();
            this.Border.Draw();
        }
        public void Close()
        {
            GUIContext.CloseWindow(this);
        }
        public void Print(string message)
        {
            //this.Activate();
            this.Writer.Write(message);
        }
        public void PrintLines(List<string> message)
        {
            //this.Activate();
            this.Writer.Write(message);
        }
    }
}
