using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {

        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowMovies()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpint = _configuration["WebApiUrl"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        return View(movieModel);
                    }
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieModel movieModel)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
            string endpoint = _configuration["WebApiUrl"] + "Movie/AddMovie";
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(endpoint, body))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie Added";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Can not Add Movie..!!";
                    }
                }
                return View();
            }

        }


    }
}