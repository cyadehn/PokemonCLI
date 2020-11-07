using System.Collections.Generic;

namespace PokemonCLI
{
    public interface ICutscene
    {
        string ScriptFileName { get; }
        List<string> CutsceneDialogue { get; }
        void Run();
    }
    public class Cutscene : ICutscene
    {
        public string ScriptFileName { get; private set; }
        public List<string> CutsceneDialogue { get; private set; }
        public Cutscene( string scriptFileName )
        {
            CutsceneDialogue = Tools.ParseScript(scriptFileName);
        }
        public void Run()
        {
            Tools.PrintDialogue(CutsceneDialogue);
        }
    }
}
