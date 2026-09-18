using Microsoft.AspNetCore.Mvc;
using SerieTrackeraspnet.Models;

namespace SerieTrackeraspnet.Controllers
{
    [ApiController]
   [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private static readonly List<Serie> series = new List<Serie>
        {
            new () { Id = 1, Title = "Breaking Bad", Season = 5, Episode = 10, Seen=true },
            new () { Id = 2, Title = "Game of Thrones", Season = 8, Episode = 11, Seen=false },
            new () { Id = 3, Title = "Stranger Things", Season = 4, Episode = 11, Seen=true },
        };

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return Ok(series);

        }

}
}
