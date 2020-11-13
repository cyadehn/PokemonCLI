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
        public void Run()
        {
            foreach (ISceneAction action in Beats)
            {
                action.Run();
            }
        }
    }
}
