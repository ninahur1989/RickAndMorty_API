using Newtonsoft.Json;
using RickAndMorty.Net.Api.Models.Domain;
using RickAndMortyApi.Data.Models;
using RickAndMortyApi.Data.Models.RickAndMorty;
using RickAndMortyApi.Services.Interfaces;
using System.Net.Http;
using System.Text;
using static System.Net.WebRequestMethods;

namespace RickAndMortyApi.Services
{
    public class RickAndMortyApiService : IRickAndMortyApiService
    {
        private static readonly HttpClient client = new HttpClient();

        const string BaseUrl = "https://rickandmortyapi.com/api";

        public async Task<Person> GetPersonByName(string name)
        {
            var response = await client.GetAsync(BaseUrl + $"/character/?name={name}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PersonRequest>(content);

            return (Person)result.Results.First();
        }

        public async Task<T> CheckAbility<T>(string name, string type)
        {
            var response = await client.GetAsync(BaseUrl + $"/{type}/?name={name}");
            var content = await response.Content.ReadAsStringAsync();
            if (content == "{\"error\":\"There is nothing here\"}")
                throw new Exception();
            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }

        public async Task<bool> CheckPersonInEpisode(string personName, string episodeName)
        {

            var person = await CheckAbility<PersonRequestId>(personName, "character");
            var episode = await CheckAbility<EpisodeRequest>(episodeName, "episode");

            if (episode.Results[0].Characters != null && episode.Results[0].Characters.Count != 0)
            {
                foreach (var item in episode.Results[0].Characters)
                {
                    if (item.EndsWith(person.Results[0].Id))
                        return true;
                }
            }
            return false;
        }
    }
}
