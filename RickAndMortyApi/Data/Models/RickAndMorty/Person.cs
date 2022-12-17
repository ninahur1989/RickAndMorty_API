using Newtonsoft.Json;

namespace RickAndMortyApi.Data.Models.RickAndMorty
{
    public class Person 
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public PersonOrigin Origin { get; set; }
    }
}
