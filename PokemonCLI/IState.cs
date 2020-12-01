namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
    {
        IGame CurrentGame { get; }
        void Start();
        void SetContext(IGame currentGame);
    }
}
