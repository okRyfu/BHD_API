using BDHStar.Models;
using BDHStar.Services;
using BHDStar.Models;
using BHDStar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BHDStar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly SessionService sessionService;
        public SessionController(SessionService sessionService)
        {
            this.sessionService = sessionService;
        }
/*        [HttpGet]
        public async Task<List<Session>> GetMovies() =>
            await sessionService.GetAsync();*/
        [HttpPost]
        public async Task<IActionResult> PostMovie(Session session,string idRoom, string idMovie)
        {
            await sessionService.CreateAsync(session,idRoom,idMovie);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMovie(Session session)
        {
            await sessionService.UpdateAsync(session);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(string id_session)
        {
            await sessionService.RemoveAsync(id_session);
            return Ok();
        }
        [HttpGet]
        public async Task<List<Session>> Paging(int page, int pagenum)
        {
            return await sessionService.Paging(page, pagenum);
        }

    }
}
