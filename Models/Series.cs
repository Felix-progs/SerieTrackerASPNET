using System.ComponentModel.DataAnnotations;

namespace SerieTrackeraspnet.Models
{
    public class Serie
    {

       
        public int Id {  get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Episode must be at least 1")]
        public int Episode { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Season must be at least 1")]
        public int Season { get; set; }

        public bool Seen { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set;} = string.Empty;

        public string? ImageUrl { get; set; }








    }
}
