using System.Collections.Generic;
using PokeAPIClient;

namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
    {
        string Name { get; }
        IGame CurrentGame { get; }
        void Start();
        void SetContext(IGame currentGame);
    }
    public class NewGameState : IState
    {
        public string Name { get; } = "New GameState";
        public IGame CurrentGame { get; private set; }
        public NewGameState()
        {
        }
        public void Start()
        {
            PlayerCharacter player = NewGame(); 
            IState state = new ContinueState();
            CurrentGame.TransitionTo(state, player); 
        }
        public void SetContext(IGame currentGame)
        {
            this.CurrentGame = currentGame;
        }
        public PlayerCharacter NewGame()
        {
            SetRegion(Program.userInput);
            Cutscene cutscene = new Cutscene("introDialogue.txt");
            cutscene.Run();
            PlayerCharacter character = new PlayerCharacter(Program.userInput);
            return character;
        }
        public void SetRegion(IUserInput userInput)
        {
            List<string> regionNames = CurrentGame.PokeRepository.GetPokedexNames();
            Tools.Typewriter.WriteDialogue("Please select your region: ");
            Tools.PrintToConsole(regionNames);
            string selection = userInput.GetUserInput();
            List<PokemonSpecies> regionalPokemon = CurrentGame.PokeRepository.GetPokemon(selection);
            CurrentGame.LoadedData.SetRegion(selection, regionalPokemon);
        }
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
