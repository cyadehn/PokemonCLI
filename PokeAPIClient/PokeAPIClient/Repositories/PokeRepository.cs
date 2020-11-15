using RestSharp;

namespace PokeAPIClient
{
    public class PokeRepository : IPokeRepository
    {
        public RestClient Client { get; private set; }
        public PokeRepository(RestClient client)
        {
            Client = client;
        }
    }
    public interface IPokeRepository
    {
        RestClient Client { get; }
    }
}
