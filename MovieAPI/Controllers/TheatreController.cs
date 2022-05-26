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
    public class TheatreController : ControllerBase
    {
        TheatreServices _theatreServices;

        public TheatreController(TheatreServices theatreServices)
        {
            _theatreServices = theatreServices;
        }

        [HttpGet("Select")]
        public IActionResult SelectTheatre()
        {
            return Ok(_theatreServices.SelectTheatre());
        }
        [HttpPost("Add")]
        public IActionResult AddTheatre(TheatreModel theatreModel)
        {
            return Ok(_theatreServices.AddTheatre(theatreModel));
        }

        public IActionResult DeleteTheatre(int ID)
        {
            return Ok(_theatreServices.DeleteTheatre(ID));
        }
    }
}
