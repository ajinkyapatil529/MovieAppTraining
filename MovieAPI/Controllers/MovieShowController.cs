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

        [HttpDelete("DeleteMovieShowtimeById")]
        public IActionResult DeleteMovieShowtimeById(int showId)
        {
            return Ok(_movieShowServices.DeleteMovieShowtime(showId));
        }

        [HttpPut("UpdateMovieShowtimeById")]
        public IActionResult UpdateMovieShowtime(MovieShowModel movieShowtimeModel)
        {
            return Ok(_movieShowServices.UpdateMovieShowtime(movieShowtimeModel));
        }

        [HttpGet("GetMovieShowtimeById")]
        public IActionResult GetMovieShowtimeById(int showId)
        {
            return Ok(_movieShowServices.GetMovieShowimeById(showId));
        }

        [HttpGet("GetShowTimesAndDateForSpecificTheatreAndMovie")]
        public IActionResult GetShowTimesAndDateForSpecificTheatreAndMovie(int movieId)
        {
            return Ok(_movieShowServices.GetShowtimeForSpecificMovieAndTheatre(movieId));
        }
    }
}
