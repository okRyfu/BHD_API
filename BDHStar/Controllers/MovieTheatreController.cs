using BDHStar.Models;
using BDHStar.Services;
using BHDStar.Models;
using BHDStar.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHDStar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieTheatreController : ControllerBase
    {
        private readonly MovieTheatreService movieTheatreService;
        public MovieTheatreController(MovieTheatreService movieTheatreService)
        {
            this.movieTheatreService = movieTheatreService;
        }
        [HttpGet]
        public async Task<List<MovieTheatres>> GetMovies() =>
            await movieTheatreService.GetAsync();
        [HttpPost]
        public async Task<IActionResult> PostMovie(MovieTheatres movieTheatre)
        {
            await movieTheatreService.CreateAsync(movieTheatre);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MovieTheatres movieTheatre)
        {
            await movieTheatreService.UpdateAsync(movieTheatre);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            await movieTheatreService.RemoveAsync(id);
            return Ok();
        }
    }
}
