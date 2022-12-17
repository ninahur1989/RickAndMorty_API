using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Net.Api.Factory;
using RickAndMortyApi.Services;
using RickAndMortyApi.Services.Interfaces;

namespace RickAndMortyApi.Controllers
{
    public class ApiController : Controller
    {
        private readonly IApiService _servise;
        public ApiController(IApiService servise)
        {
            _servise = servise;
        }

        [Route("api/v1/check-person")]
        [HttpGet]
        public async Task<IActionResult> Check(string personName, string episodeName)
        {
            try
            {
                var result = await _servise.CheckPerson(personName, episodeName);
                return Json(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(404);
            }
        }

        [Route("api/v1/person")]
        [HttpGet]
        public async Task<IActionResult> Person(string name)
        {
            var result = await _servise.GetPerson(name);
            if (result != null)
            {
                Json(result);
            }

            return Json(404);
        }
    }
}
