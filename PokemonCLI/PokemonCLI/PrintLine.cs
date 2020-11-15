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
        public void Run()
        {
            Tools.PrintToConsole(_lines);
        }
    }
}
