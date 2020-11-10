namespace PokemonCLI
{
    public class PlayerCharacter : Character
    {
        //public PokemonBox Box { get; private set; }
        //public PlayerStats Stats { get; private set; }
        public PlayerSettings Settings { get; private set; }
        public PlayerCharacter(IUserInput userInput) : base(userInput)
        {

        }
        public override void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput("Please enter your first name: ");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                Tools.Typewriter.WriteDialogue("Shy, huh? Well, how about we just call you Kid for now?");
                Name = "Kid";
            }
        }
        public class PlayerSettings
        {

        }
    }
}
