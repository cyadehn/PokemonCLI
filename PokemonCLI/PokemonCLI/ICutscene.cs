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
        public IWindow Window { get; set; }
        public void Run()
        {
            this.Window = new BasicWindow();
            Program.GUI.CloseAll();
            Program.GUI.OpenWindow(this.Window, 0);
            Program.GUI.Refresh();
            foreach (ISceneAction action in Beats)
            {
                action.Run(this.Window);
            }
        }
    }
}
