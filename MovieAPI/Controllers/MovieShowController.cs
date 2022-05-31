using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApp.Business.Services;
using MovieApp.Entity;
namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieShowController : ControllerBase
    {
        MovieShowServices _movieShowServices;
        public MovieShowController(MovieShowServices movieShowServices)
        {
            _movieShowServices = movieShowServices;
        }
        [HttpGet("MovieShows")]
        public IActionResult MovieShows()
        {
            return Ok(_movieShowServices.movieShows());
        }
        
        [HttpPost("InsertShow")]
        public IActionResult InsertShow(MovieShowModel movieShowModel)
        {
            return Ok(_movieShowServices.InsertShow(movieShowModel));
        }
    }
}
