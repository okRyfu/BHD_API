using Microsoft.AspNetCore.Mvc;
using BDHStar.Services;
using BDHStar.Models;

namespace BHDStar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService movieService;
        public MoviesController(MovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        public async Task<List<Movies>>GetMovies()=>
            await movieService.GetAsync();
        [HttpPost]
        public async Task<IActionResult> PostMovie(Movies movie)
        {
            await movieService.CreateAsync(movie);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Movies movie)
        {
            await movieService.UpdateAsync(movie);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(string id_movie)
        {
            await movieService.RemoveAsync(id_movie);
            return Ok();
        }
    }
}
