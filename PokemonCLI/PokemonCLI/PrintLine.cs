using BasicGUI;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class PrintLine : ISceneAction
    {
        private List<string> _lines = new List<string>();
        public PrintLine(List<string> lines)
        {
            _lines = lines;
        }
        public void Run(IWindow window)
        {
            window.Writer.PrintToConsole(_lines);
        }
    }
}
