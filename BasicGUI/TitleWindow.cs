using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace BasicGUI
{
    public class TitleWindow : IWindow
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
        private List<string> TitleText { get; set; }
        public TitleWindow(Assembly assembly, string resourceName)
        {
            this.Border = new Border(this);
            this.Writer = new WindowWriter(this);
            this.TitleText = this.SetTitleText(assembly, resourceName);
        }
        public void Activate()
        {
            Console.SetCursorPosition(this.BufferLeft, this.BufferTop);
        }
        public void Redraw(BufSettings dim)
        {
            this.BufferWidth = dim.Width;
            this.BufferHeight = dim.Height;
            this.BufferTop = dim.Top;
            this.BufferLeft = dim.Left;
            //Console.WriteLine("Redrawing windows...");
            this.Redraw();
        }
        public void Redraw()
        {
            this.Writer.ResetPosition();
            this.Border.Draw();
            this.PrintLines(this.TitleText);
        }
        public void Close()
        {
            GUIContext.CloseWindow(this);
        }
        private List<string> SetTitleText(Assembly entryAssembly, string resourceName)
        {
            List<string> scriptLines = new List<string>();
            using (var stream = entryAssembly.GetManifestResourceStream(resourceName))
            using ( var reader = new StreamReader(stream))
                {
                    string line;
                    while ( (line = reader.ReadLine()) != null )
                    {
                        scriptLines.Add(line);
                    }
                }
            return scriptLines;
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
