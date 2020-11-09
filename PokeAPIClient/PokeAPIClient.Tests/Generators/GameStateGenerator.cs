using Xunit;
using System.Collections.Generic;
using RestSharp;

namespace PokeAPIClient.Tests
{
    // TODO: use AppDomain to get all classes implementing IState, then Activate.CreateInstance(type) for each of the types returned
    public class PokedexNameGenerator : TheoryData<string>
    {
        private RestClient _client = new RestClient("https://pokeapi.co/api/v2/");
        public PokedexNameGenerator()
        {
            var pokeRepo = new PokeRepository(_client);
            List<string> names = pokeRepo.GetPokedexNames();
            foreach ( string name in names )
            {
                Add(name);
            }
        }
    }
}
