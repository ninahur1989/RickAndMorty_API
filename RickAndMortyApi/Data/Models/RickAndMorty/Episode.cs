using Newtonsoft.Json;

namespace RickAndMortyApi.Data.Models.RickAndMorty
{
    public class Episode
    {
        public string Id { get; set; }
        public List<string> Characters { get; set; }
    }
}
