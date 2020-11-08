using Xunit;

namespace PokemonCLI.Tests
{
    public class GameStateGenerator : TheoryData<IState>
    {
        public GameStateGenerator()
        {
            Add(new NewGameState());
            Add(new ContinueState());
        }
    }
}
