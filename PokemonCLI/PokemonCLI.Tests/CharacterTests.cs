using Xunit;
using RestSharp;

namespace PokemonCLI.Tests
{
    public class CharacterTests
    {
        public RestClient Client { get; private set; } = new RestClient("https://pokeapi.co/api/v2/");
        [Fact]
        public void PlayerCharacter_SetCharacterName_UserInputString()
        {
            IUserInput userInput = new MockUserInput();
            string expected = userInput.GetUserInput("PROMPT STAND-IN");

            PlayerCharacter target = new PlayerCharacter(userInput);

            Assert.Equal(target.Name, expected);
        }
        [Fact]
        public void PlayerCharacter_SetCharacterName_UserInputNullReturnsKid()
        {
            IUserInput userInput = new MockNullUserInput();
            string expected = "Kid";

            PlayerCharacter target = new PlayerCharacter(userInput);

            Assert.Equal(target.Name, expected);
        }
    }
}
