using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.MovieModels
{
    public class MovieListItem
    {
        public int Id { get; set; }

        [Display(Name = "Movie Title")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Parental Guidance")]
        public string ParentalGuidance { get; set; }

        public string Genre { get; set; }

        public double Rating { get; set; }

        public string Description { get; set; }

        [Display(Name = "Main Character")]
        public string MainCharacters { get; set; }
        //public List<string> PlacesToWatch { get; set; } = new List<string>();
    }
}
