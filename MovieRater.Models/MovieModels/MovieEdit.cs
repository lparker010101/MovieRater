using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.MovieModels
{
    public class MovieEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ParentalGuidance { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public string MainCharacters { get; set; }
        public List<string> PlacesToWatch { get; set; } = new List<string>();
    }
}