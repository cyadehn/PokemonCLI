using RestSharp;

namespace PokeAPIClient
{
    public class ItemRepository
    {
        public RestClient Client { get; private set; }
        public ItemRepository(RestClient client)
        {
            Client = client;
        }
    }
    public interface IItemRepository
    {
        RestClient Client { get; }
    }
}
