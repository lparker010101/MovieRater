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
        private readonly Guid _Id; // make an _id of type Guid

        public MovieService(Guid id)
        {
            _Id = id;
        }


        // Delete Movie
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
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        //Get Movie
        public async Task<IEnumerable<MovieListItem>> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Movies
                    .Select(c => new MovieListItem
                    {
                        Id = c.Id,
                        Title = c.Title,
                        ReleaseDate = c.ReleaseDate,
                        ParentalGuidance = c.ParentalGuidance,
                        Genre = c.Genre,
                        Rating = c.Rating,
                        MainCharacters = c.MainCharacters,
                        Description = c.Description,
                    }).ToListAsync();
                return query;
            }
        }

        //Put/Update Movie

        public async Task<bool> Put(MovieEdit movie, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldMovieData = await ctx.Movies.FindAsync(id);
                if (oldMovieData is null)
                {
                    return false;
                }

                oldMovieData.Title = movie.Title;
                oldMovieData.ReleaseDate = movie.ReleaseDate;
                oldMovieData.ParentalGuidance = movie.ParentalGuidance;
                oldMovieData.Genre = movie.Genre;
                oldMovieData.Rating = movie.Rating;
                oldMovieData.Description = movie.Description;
                oldMovieData.MainCharacters = movie.MainCharacters;

                return await ctx.SaveChangesAsync() > 0;
            }


        }

        // Post Movie
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
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}











