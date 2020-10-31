using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using PokeAPIClient;

namespace PokemonCLI
{
    class Program
    {
        private static RestClient restClient = new RestClient(); 
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            Game game = new Game(restClient);
            game.Start();
        }
    }

    public class Game 
    {
        private static RestClient _restClient;
        private PokeRepository pokeRepository = new PokeRepository(_restClient);
        private IState gameState;
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public PlayerData playerData { get; private set; }

        public Game(RestClient restClient)
        {
            _restClient = restClient;
            playerData = new PlayerData();
            if ( playerData.Continue == true )
            {
                gameState = new ContinueState();//TODO: START HERE, FURTHER DEFINE STATE INTERFACE, THEN MOVE ON TO CONCRETE STATES
            }
            else if ( playerData.Continue != true )
            {
                gameState = new NewGameState();
            }
            gameState.Start();
        }
        public void Start()
        {
            while ( gameState != null )
            {
                gameState.Start();	
            }
        }
        public void TransitionTo(IState state)
        {}
        public void Quit()
        {
            gameState = null;
        }
    }

    public static class Tools
    {
        public static List<string> ReadDialogue(string fileName)
        {
            List<string> dialogue = new List<string>();
            string fileLocation = string.Format("dialogue/{0}", fileName);
            using ( var reader = new StreamReader(fileLocation))
            {
                string line;
                while ( (line = reader.ReadLine()) != null )
                {
                    dialogue.Add(line);
                }
            }
            return dialogue;
        }

        public static class Typewriter
        {
            public static void WriteDialogue(string line)
                {
                    foreach (char c in line)
                    {
                        Console.Write(c);
                        CharacterDelay(c);
                    }
                    Console.Write("\n\r");
                }
            private static void CharacterDelay(char c)
                {
                    if (c == '.' )
                    {
                        Thread.Sleep(300);
                    }
                    else if ( c == ',' )
                    {
                        Thread.Sleep(50);
                    }
                    else 
                    {
                        Thread.Sleep(15);
                    }
                }
        }

        public static void PrintDialogue(List<string> dx)
        {
            foreach ( string line in dx )
            {
                Typewriter.WriteDialogue(line);
                Thread.Sleep(1000);
                for ( int i = 0; i < line.Length/15; i++ )
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Write("\n\r");
            }
        }
    }
}
