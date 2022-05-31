using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Entity;
namespace MovieApp.UI.Controllers
{
    public class MovieShowController : Controller
    {
        IConfiguration _configuration;
        public MovieShowController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiUrl"] + "MovieShow/MovieShows";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<List<MovieShowModel>>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }

            return View();
        }

    }
}
