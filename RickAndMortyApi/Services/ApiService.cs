using RickAndMorty.Net.Api.Factory;
using RickAndMorty.Net.Api.Service;
using RickAndMortyApi.Data.Models.RickAndMorty;
using RickAndMortyApi.Services.Interfaces;

namespace RickAndMortyApi.Services
{
    public class ApiService : IApiService
    {
        private readonly IRickAndMortyApiService _rickAndMortyService;

        public ApiService(IRickAndMortyApiService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        public async Task<bool> CheckPerson(string personName, string episodeName)
        {
            return  await _rickAndMortyService.CheckPersonInEpisode(personName, episodeName);
        }

        public async Task<Person> GetPerson(string personName)
        {
            return await _rickAndMortyService.GetPersonByName(personName);
        }
    }
}
