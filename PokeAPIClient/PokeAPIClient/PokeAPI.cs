using RestSharp;

namespace PokeAPIClient
{
    public class PokeAPI
    {
        public RestClient Client { get; private set; }
        public PokeRepository PokeRepository { get; private set; }
        public PokeAPI()
        {
            Client = new RestClient("https://pokeapi.co/api/v2/");
            PokeRepository = new PokeRepository(Client);
        }
    }
}
