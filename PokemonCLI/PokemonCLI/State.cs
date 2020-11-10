namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
    {
        string Name { get; }
        IGame CurrentGame { get; }
        void Start();
        void SetContext(IGame currentGame);
    }
    public class ContinueState : IState
    {
        public string Name { get; private set; } = "Continue GameState";
        public IGame CurrentGame { get; private set; }
        public ContinueState()
        {
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
