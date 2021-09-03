using MovieRater.Data;
using MovieRater.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services.MovieServices
{
    public class MovieService
    {
        private readonly Guid _id; // making an _id of type Guid

        public MovieService(Guid id)
        {
            _id = id; // takes in an id of type Guid and sets it = to our _id to be used 
        }

        
        public async Task<bool> Post(MovieCreate movie)
        {
            Movie entity = new Movie
            {
                Title = movie.Title,
                ReleaseDate = movie.ReleaseDate,
                ParentalGuidance = movie.ParentalGuidance,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Description = movie.Description,
                MainCharacters = movie.MainCharacters,
                PlacesToWatch = movie.PlacesToWatch
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return await ctx.SaveChangesAsync() > 1;
            }
                
        }
        
    }


}
