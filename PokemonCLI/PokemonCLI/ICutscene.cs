using BasicGUI;
using System.Collections.Generic;

namespace PokemonCLI
{
    public interface ICutscene
    {
        List<ISceneAction> Beats { get; }
        void Run();
    }
    public class Cutscene : ICutscene
    {
        public List<ISceneAction> Beats { get; set; }
        public List<IWindow> Windows { get; set; } = new List<IWindow>();
        public void Run()
        {
            Windows.Add(new BasicWindow());
            foreach (ISceneAction action in Beats)
            {
                action.Run(Windows[0]);
            }
        }
    }
}
