using System.Collections.Generic;

namespace PokemonCLI
{
    public class Dialogue : ISceneAction
    {
        public List<string> DialogueLines { get; set; }
        public Dialogue(List<string> lines)
        {
            DialogueLines = lines;
        }
        public void Run()
        {
            Tools.PrintDialogue(DialogueLines);
        }
    }
}
