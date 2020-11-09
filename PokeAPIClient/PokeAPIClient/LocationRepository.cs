using RestSharp;

namespace PokeAPIClient
{
    public class LocationRepository
    {
        public RestClient Client { get; private set; }
        public LocationRepository( RestClient client )
        {

        }
    }
    public interface ILocationRepository
    {
        RestClient Client { get; }
    }
}
