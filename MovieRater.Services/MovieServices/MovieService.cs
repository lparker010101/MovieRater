using MovieRater.Data;
using MovieRater.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        
        public async Task<IEnumerable<MovieListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    await
                    ctx
                    .Movies
                    .Select(d => new MovieListItem
                    {
                        Id = d.Id,
                        Title = d.Title,
                        ReleaseDate = d.ReleaseDate,
                        Genre = d.Genre,
                        Rating = d.Rating
                    }).ToListAsync();
                return query;
            }
        }

        public async Task<bool> Put(MovieEdit movie, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldMovieData = await ctx.Movies.FindAsync(id);
                if (oldMovieData is null)
        {
                    return false;
                }

                oldMovieData.Id = movie.Id;
                oldMovieData.Title = movie.Title;
                oldMovieData.ReleaseDate = movie.ReleaseDate;
                oldMovieData.ParentalGuidance = movie.ParentalGuidance;
                oldMovieData.Genre = movie.Genre;
                oldMovieData.Rating = movie.Rating;
                oldMovieData.Description = movie.Description;
                oldMovieData.MainCharacters = movie.MainCharacters;
                oldMovieData.PlacesToWatch = movie.PlacesToWatch;

                return await ctx.SaveChangesAsync() > 0;
            }


        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldMovieData = await ctx.Movies.FindAsync(id);
                if (oldMovieData is null)
                {
                    return false;
                }
                ctx.Movies.Remove(oldMovieData);
                return await ctx.SaveChangesAsync() > 1;
            }
        }
        
    }


}
