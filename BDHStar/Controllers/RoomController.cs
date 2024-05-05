using BHDStar.Models;
using BHDStar.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace BHDStar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpGet]
        public async Task<List<Room>> GetMovies() =>
            await roomService.GetAsync();
        [HttpPost]
        public async Task<IActionResult> PostMovie(Room room,string id)
        {
            await roomService.CreateAsync(room,id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Room update)
        {
            await roomService.UpdateAsync(update);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(string id)
        {
            await roomService.RemoveAsync(id);
            return Ok();
        }
    }
}
