using System.Linq;
using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace PokeAPIClient
{
    public class LocationRepository : ILocationRepository
    {
        public RestClient Client { get; private set; }
        public LocationRepository( RestClient client )
        {
            Client = client;
        }
        public PokedexResponse GetPokedex(string region)
        {
            region = (region == "") ? region = "kanto" : region;
            var request = new RestRequest(string.Format("pokedex/{0}", region), Method.GET);
            IRestResponse<PokedexResponse> response = Client.Execute<PokedexResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                request = new RestRequest(string.Format("pokedex/{0}", "kanto"));
                response = Client.Execute<PokedexResponse>(request);
            }
            return response.Data;
        }
        public int GetPokedexCount()
        {
            int dexCount;
            var request = new RestRequest("pokedex", Method.GET);
            IRestResponse<PokedexIndexResponse> response = Client.Execute<PokedexIndexResponse>(request);
            dexCount = response.Data.Results.Count;
            return dexCount;
        }
        public List<(string name, string description)> GetPokedexNamesAndDescriptions()
        {
            List<(string name, string description)> output = new List<(string name, string description)>();
            List<string> pokedexNames = new List<string>();

            int dexCount = GetPokedexCount();
            var request = new RestRequest("pokedex?limit={limit}", Method.GET);
            request.AddUrlSegment("limit", string.Format("{0}", dexCount));
            IRestResponse<PokedexIndexResponse> response = Client.Execute<PokedexIndexResponse>(request);

            pokedexNames = response.Data.Results
                .Select( r => r.Name )
                .ToList();
            List<PokedexResponse> pokedexResponses = new List<PokedexResponse>();
            foreach ( string name in pokedexNames )
            {
                output.Add((name, GetPokedex(name).Descriptions[0].DescriptionStr));
            }
            return output;
        }
    }
    public interface ILocationRepository
    {
        RestClient Client { get; }
    }
}
