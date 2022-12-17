using RickAndMortyApi.Data.Models.RickAndMorty;

namespace RickAndMortyApi.Services.Interfaces
{
    public interface IRickAndMortyApiService
    {
        public Task<Person> GetPersonByName(string name);
        public Task<bool> CheckPersonInEpisode(string personName, string episodeName);
    }
}
