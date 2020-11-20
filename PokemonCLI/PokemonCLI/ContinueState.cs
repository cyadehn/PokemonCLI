using BasicGUI;

namespace PokemonCLI
{
    public class ContinueState : IState
    {
        public string Name { get; private set; } = "Continue GameState";
        public IGame CurrentGame { get; private set; }
        public IWindow Window { get; set; }
        public ContinueState()
        {
            this.Window = new BasicWindow();
            Program.GUI.CloseAll();
            Program.GUI.OpenWindow(this.Window, 0);
            Program.GUI.Refresh();
        }
        public void Start()
        {

        }
        public void SetContext(IGame currentGame)
        {
            this.CurrentGame = currentGame;
        }
    }
}
