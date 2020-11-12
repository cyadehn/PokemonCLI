using System;
using System.IO;
using System.Collections.Generic;

namespace PokemonCLI
{
    public static class CutsceneMap
    {
        private static Dictionary<string, Func<Cutscene>> _cutscenes = new Dictionary<string, Func<Cutscene>>()
        {
            {"intro", () => { return ParseScript("PokemonCLI.cutscene_scripts.introDialogue.txt"); }}
        };
        private static Dictionary<string, Func<List<string>, ISceneAction>> _actionTypeMap = new Dictionary<string, Func<List<string>, ISceneAction>>()
        {
            {"dialogue", (List<string> lines) => { return new Dialogue(lines); }}
        };
        public static Cutscene ParseScript(string resourceName)
        {
            List<string> lines = GetScriptLines(resourceName);
            List<ISceneAction> actions = new List<ISceneAction>();
            foreach ( string line in lines )
            {
                actions.Add(ParseScriptLine(line));
            }
            Cutscene Cutscene = new Cutscene()
            {
                Beats = actions
            };
            return Cutscene;
        }
        private static List<string> GetScriptLines(string resourceName)
        {
            List<string> scriptLines = new List<string>();
            using (var stream = Tools.Assembly.GetManifestResourceStream(resourceName))
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
        private static ISceneAction ParseScriptLine(string line)
        {
            string[] splitLine = line.Split(' ', 2);
            string actionType = splitLine[0];
            List<string> parameters = new List<string>();
            for ( var i = 1; i < splitLine.Length; i ++ )
            {
                parameters.Add(splitLine[i]);
            }
            ISceneAction action = _actionTypeMap[actionType](parameters);
            return action;
        }
        public static void Run(string key)
        {
            Cutscene scene = _cutscenes[key]();
            scene.Run();
        }
    }
    public interface ICutscene
    {
        List<ISceneAction> Beats { get; }
        void Run();
    }
    public class Cutscene : ICutscene
    {
        public List<ISceneAction> Beats { get; set; }
        public void Run()
        {
            foreach (ISceneAction action in Beats)
            {
                action.Run();
            }
        }
    }
    public interface ISceneAction
    {
        void Run();
    }
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
