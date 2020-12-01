using Xunit;

namespace PokemonCLI.Tests
{
    // TODO: use AppDomain to get all classes implementing IState, then Activate.CreateInstance(type) for each of the types returned
    public class GameStateGenerator : TheoryData<IState>
    {
        public GameStateGenerator()
        {
            //Add(new NewGameState());
            Add(new ContinueState());
        }
    }
}
