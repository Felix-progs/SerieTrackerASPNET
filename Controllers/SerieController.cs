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

        [HttpPost]
        public IActionResult AddSerie(Serie serie)
        {
            serie.Id = series.Count == 0 ? 1 : series.Max(s => s.Id) + 1;
            series.Add(serie);
            return CreatedAtAction(nameof(GetSeries), new { id = serie.Id }, serie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSerie(int id, Serie updatedSerie)
        {
            var serie = series.FirstOrDefault(s => s.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            serie.Title = updatedSerie.Title;
            serie.Season = updatedSerie.Season;
            serie.Episode = updatedSerie.Episode;
            serie.Seen = updatedSerie.Seen;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSerie(int id)
        {
            var serie = series.FirstOrDefault(s => s.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            series.Remove(serie);
            return NoContent();
        }
        [HttpPost("{id}/image")]
public async Task<IActionResult> UploadImage(int id, IFormFile file)
{
    var serie = series.FirstOrDefault(s => s.Id == id);
    if (serie == null)
        return NotFound();

    if (file.Length == 0)
        return BadRequest("Ingen fil vald");

    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
    var filePath = Path.Combine("wwwroot/uploads", fileName);

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
        await file.CopyToAsync(stream);
    }

    serie.ImageUrl = $"/uploads/{fileName}";

    return Ok(new { imageUrl = serie.ImageUrl });
}

    }
}
