using RickAndMorty.Net.Api.Service;
using RickAndMortyApi.Data.Models.RickAndMorty;

namespace RickAndMortyApi.Services.Interfaces
{
    public interface IApiService
    {
        public Task<bool> CheckPerson(string personName, string episodeName);
        public Task<Person> GetPerson(string personName);
    }
}
