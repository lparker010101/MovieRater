using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.MovieModels
{
    public class MovieCreate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Parental Guidance")]
        public string ParentalGuidance { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Main Character")]
        public string MainCharacters { get; set; }

        //[Required]
        //public List<string> PlacesToWatch { get; set; } = new List<string>();
    }
}
