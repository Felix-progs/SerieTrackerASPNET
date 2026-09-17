using System.ComponentModel.DataAnnotations;

namespace SerieTrackeraspnet
{
    public class Serie
    {

       
        public int Id {  get; set; }
        
        public int Episode { get; set; }

        public int Season { get; set; }

        public bool Seen { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set;} = string.Empty;








    }
}
