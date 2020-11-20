using System;

namespace BasicGUI
{
    public class UserInput : IUserInput
    {
        public string GetUserInput(IWindow window)
        {
            Console.WriteLine("Please type your selection: ");
            return Console.ReadLine();
        }
        public string GetUserInput(IWindow window, string prompt)
        {
            window.Writer.Typewriter.PrintChars(prompt);
            return Console.ReadLine();
        }
    }
    public interface IUserInput
    {
        string GetUserInput(IWindow window, string prompt);
        string GetUserInput(IWindow window);
    }
}
