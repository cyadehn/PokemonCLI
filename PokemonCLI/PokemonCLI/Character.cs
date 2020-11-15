using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class Character
    {
        public string Name { get; protected set; }
        public List<PokemonSpecies> Pokemon { get; private set; }
        //public List<Item> Items { get; private set; }
        public Character(IUserInput userInput)
        {
            SetCharacterName(userInput);

        }
        public virtual void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput("Enter character name:");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                Tools.Typewriter.PrintChars("Hm. Well, how about we call them person for now?");
                Name = "Person";
            }
        }
    }
}
