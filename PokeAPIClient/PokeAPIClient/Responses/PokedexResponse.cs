using System.Collections.Generic;

namespace PokeAPIClient
{
    public class PokedexResponse    
	{
        public List<Description> Descriptions { get; set; } 
        public int Id { get; set; } 
        public bool IsMainSeries { get; set; } 
        public string Name { get; set; } 
        public List<Name> Names { get; set; } 
        public List<PokemonEntry> PokemonEntries { get; set; } 
        public Region Region { get; set; } 
        public List<VersionGroup> VersionGroups { get; set; } 
    }
    public class Language    
	{
        public string Name { get; set; } 
        public string Url { get; set; } 
    }
    public class Description    
	{
        public string DescriptionStr { get; set; } 
        public Language Language { get; set; } 
    }
    public class Language2    
	{
        public string Name { get; set; } 
        public string Url { get; set; } 
    }
    public class Name    
	{
        public Language2 Language { get; set; } 
        public string NameStr { get; set; } 
    }
    public class PokemonSpecies    
	{
        public string Name { get; set; } 
        public string Url { get; set; } 
    }
    public class PokemonEntry    
	{
        public int EntryNumber { get; set; } 
        public PokemonSpecies PokemonSpecies { get; set; } 
    }
    public class Region    
	{
        public string Name { get; set; } 
        public string Url { get; set; } 
    }
    public class VersionGroup    
	{
        public string Name { get; set; } 
        public string Url { get; set; } 
    }
}
