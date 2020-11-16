using RestSharp;

namespace PokeAPIClient
{
    public class PokeAPI
    {
        public RestClient Client { get; private set; }
        public static PokeRepository PokeRepository { get; private set; }
        public static LocationRepository LocationRepository { get; private set; }
        public PokeAPI()
        {
            Client = new RestClient("https://pokeapi.co/api/v2/");
            PokeRepository = new PokeRepository(Client);
            LocationRepository = new LocationRepository(Client);
        }
    }
}
