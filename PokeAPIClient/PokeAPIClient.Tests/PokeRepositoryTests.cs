using Xunit;
using System;
using RestSharp;
using System.Collections.Generic;

namespace PokeAPIClient.Tests
{
    public class PokeRepositoryTests
    {
        public static RestClient Client { get; private set; } = new RestClient("https://pokeapi.co/api/v2/");
        [Fact]
        public void PokeRepository_GetPokemon_PassingStringReturnsPokemonSpeciesListObject()
        {
            var pokeRepo = new PokeRepository(Client);
            List<PokemonSpecies> target = pokeRepo.GetPokemon("string");
            Assert.IsType<List<PokemonSpecies>>(target);
        }
        [Fact]
        public void PokeRepository_GetPokemon_PassingValidStringReturnsListWithCountGreaterThanZero()
        {
            var pokeRepo = new PokeRepository(Client);
            List<PokemonSpecies> target = pokeRepo.GetPokemon("kanto");
            bool expected = target.Count > 0;
            Assert.True(expected);
            Assert.NotNull(target);
        }
        //[Fact]
        //public void PokeRepository_GetPokemon_ReturnsNullIfStatusCodeIsNotOK()
        //{
        //}
        [Theory]
        [InlineData("kanto")]
        public void PokeRepository_GetPokedex_PassingValidStringReturnsCorrectPokedexResponse(string region)
        {
            var pokeRepo = new PokeRepository(Client);
            PokedexResponse target = pokeRepo.GetPokedex(region);
            Assert.True(target.Name == region);
        }
        [Fact]
        public void PokeRepository_GetPokedex_PassingNullStringReturnsKantoPokedex()
        {
            var pokeRepo = new PokeRepository(Client);
            PokedexResponse target = pokeRepo.GetPokedex("");
            Assert.True(target.Name == "kanto");
        }
        //[Fact]
        //public void PokeRepository_GetPokedex_ReturnsNullIfStatusCodeIsNotOK()
        //{
        //}
        [Fact]
        public void PokeRepository_GetPokedexCount_ReturnsTypeInt()
        {
            var pokeRepo = new PokeRepository(Client);
            int target = pokeRepo.GetPokedexCount();
            Console.WriteLine($"The number of available pokedexes is {target}");
            Assert.IsType<int>(target);
        }
        //[Fact]
        //public void PokeRepository_GetPokedexCount_ReturnsNullIfStatusCodeIsNotOK()
        //{
        //}
        [Fact]
        public void PokeRepository_GetPokedexNames_ReturnsListOfStrings()
        {
            var pokeRepo = new PokeRepository(Client);
            List<string> target = pokeRepo.GetPokedexNames();
            foreach ( string name in target )
            {
                Console.WriteLine(name);
            }
            Assert.IsType<List<string>>(target);
            Assert.NotNull(target);
        }
        //[Fact]
        //public void PokeRepository_GetPokedexNames_ReturnsNullIfStatusCodeIsNotOK()
        //{
        //}
    }
}
