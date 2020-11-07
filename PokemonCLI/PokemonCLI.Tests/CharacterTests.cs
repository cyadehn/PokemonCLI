using System;
using Xunit;

namespace PokemonCLI.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void Character_Constructor_UserInputString()
        {
            IUserInput userInput = new MockUserInput();
            string expected = userInput.GetUserInput("PROMPT STAND-IN");

            Character target = new Character(userInput);

            Assert.Equal(target.Name, expected);
        }
        [Fact]
        public void Character_Constructor_UserInputNull()
        {
            IUserInput userInput = new MockNullUserInput();
            string expected = "Kid";

            Character target = new Character(userInput);

            Assert.Equal(target.Name, expected);
        }
    }
}
