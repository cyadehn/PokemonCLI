using BasicGUI;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class NewGameState : IState
    {
        public string Name { get; } = "New GameState";
        public IGame CurrentGame { get; private set; }
        public NewGameState()
        {
        }
        public void Start()
        {
            CutsceneMap.Run("intro");
            this.ChooseStarter();
            IState state = new ContinueState();
            CurrentGame.TransitionTo(state); 
        }
        public void SetContext(IGame currentGame)
        {
            this.CurrentGame = currentGame;
        }
        private void ChooseStarter()
        {
            //Program.GUI.Refresh();
            //CutsceneMap.Run("starter");
            //List<IWindow> starterWindows = new List<IWindow>();
            //IWindow window1 = new BasicWindow();
            //IWindow window2 = new BasicWindow();
            //IWindow window3 = new BasicWindow();
            //Program.GUI.OpenWindows(starterWindows, 0);
        }
    }
}
