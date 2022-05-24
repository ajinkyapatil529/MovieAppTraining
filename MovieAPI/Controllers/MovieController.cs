using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MovieApp.Business.Services;
using MovieApp.Entity;
namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieServices _movieServices;

        public MovieController(MovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieServices.SelectMovie());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            return Ok(_movieServices.AddMovie(movieModel));
        }
    }
}
