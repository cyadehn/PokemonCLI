using System;

namespace BasicGUI
{
    public class UserInput : IUserInput
    {
        public string GetUserInput(IWindow window)
        {
            string output = "";
            window.Writer.PrintToConsole("Please type your selection: ");
            output = Console.ReadLine();
            return output;
        }
        public string GetUserInput(IWindow window, string prompt)
        {
            string output = "";
            window.Writer.PrintPromptToConsole(prompt);
            output = Console.ReadLine();
            window.Writer.AdvanceLine();
            return output;
        }
    }
    public interface IUserInput
    {
        string GetUserInput(IWindow window, string prompt);
        string GetUserInput(IWindow window);
    }
}
