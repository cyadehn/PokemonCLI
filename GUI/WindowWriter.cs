using System;
using System.Threading;
using System.Collections.Generic;

namespace GUIPractice
{
    public class WindowWriter
    {
        private (int left, int top) _position;
        public IWindow Window { get; set; }
        public (int left, int top) CurrentPosition 
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
                Console.SetCursorPosition(this._position.left, this._position.top);
            }
        }
        public bool CursorReset => this.CurrentPosition.top >= this.Window.LastLine;
        public WindowWriter(IWindow window)
        {
            this.Window = window;
            this.CurrentPosition = (this.Window.BufferLeft, this.Window.BufferTop);
        }
        public void Activate()
        {
            Console.SetCursorPosition(this.CurrentPosition.left, this.CurrentPosition.top);
        }
        public void Write(string text)
        {
            this.Activate();
            Thread.Sleep(GUI.DebugSleepTime);
            if ( text.Length < this.Window.BufferWidth )
            {
                Console.WriteLine(text);
                this.AdvanceLine();
            }
            else
            {
                IEnumerable<string> messageLines = this.WordSplit(text, this.Window.BufferWidth);
                foreach ( string messageLine in messageLines )
                {
                    Console.WriteLine(messageLine);
                    this.AdvanceLine();
                }
            }
        }
        public void Write(IEnumerable<string> text)
        {
            foreach (string line in text)
            {
                this.Write(line);
            }
        }
        public IEnumerable<string> Split(string str, int maxLength)
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
        public IEnumerable<string> WordSplit(string str, int maxLength)
        {
            if (String.IsNullOrEmpty(str))
            {
                throw new ArgumentException();
            }
            string[] words = str.Split(' ');
            string result = "";
            int index = 0;
            while (index < words.Length)
            {
                if ( (result + words[index]).Length > maxLength  )
                {
                    index++;
                    IEnumerable<string> singleWordLines = this.Split(words[index], maxLength);
                    foreach (string line in singleWordLines)
                    {
                        yield return line;
                        continue;
                    }
                }
                while ( index < words.Length && !( (result + words[index] + " ").Length > maxLength ) )
                {
                    result += words[index] + " ";
                    index++;
                }
                yield return result;
                result = "";
            }
            
        }
        public void AdvanceLine()
        {
            if (this.CursorReset == true)
            {
                this.ResetPosition();
            }
            else
            {
                this.CurrentPosition = (this.CurrentPosition.left, this.CurrentPosition.top + 1);
            }
        }
        public void ResetPosition()
        {
            this.CurrentPosition = (this.Window.BufferLeft, this.Window.BufferTop);
        }
    }
}
