namespace PokemonCLI.Tests
{
    public class MockUserInput : PokemonCLI.IUserInput
    {
        public string GetUserInput(string prompt)
        {
            return "TEST INPUT";
        }
    }
    public class MockNullUserInput : PokemonCLI.IUserInput
    {
        public string GetUserInput(string prompt)
        {
            return "";
        }
    }
}
