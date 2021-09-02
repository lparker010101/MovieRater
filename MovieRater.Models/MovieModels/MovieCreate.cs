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
        
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string ParentalGuidance { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        public string MainCharacters { get; set; }

        [Required]
        public List<string> PlacesToWatch { get; set; } = new List<string>();

    }
}
