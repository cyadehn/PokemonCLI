namespace PokemonCLI
{
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
