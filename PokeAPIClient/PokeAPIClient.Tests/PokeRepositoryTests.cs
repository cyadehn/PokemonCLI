using Xunit;
using RestSharp;
using System.Collections.Generic;

namespace PokeAPIClient.Tests
{
    public class PokeRepositoryTests
    {
        public static RestClient Client { get; private set; } = new RestClient("https://pokeapi.co/api/v2/");
        [Fact]
        public void PokeRepository_GetPokemon_PassingValidStringReturnsListOfPokemon()
        {
            var pokeRepo = new PokeRepository(Client);
            List<Pokemon> target = pokeRepo.GetPokemon("kanto");
            Assert.IsType<List<Pokemon>>(target);
        }
    }
}
