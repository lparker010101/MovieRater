using MovieRater.Data;
using MovieRater.Models.TVShowModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services.TVShowServices
{
    public class TVShowService
    {
        private readonly Guid _Id;
        public TVShowService(Guid id)
        {
            _Id = id;
        }

        public async Task<bool> CreateTVShow(TVShowCreate model)
        {
            var entity =
                new TVShow() // This creates an instance of TVShow.
                {
                    Title = model.Title,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TVShows.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<TVShowListItem>> GetTVShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .TVShows
                    .Select(c => new TVShowListItem
                    {
                        Id = c.Id,
                        Title = c.Title,
                        ReleaseDate = c.ReleaseDate,
                        Genre = c.Genre,
                        Description = c.Description,
                    }).ToListAsync();
                return query;
            }
        }

        public async Task<TVShowDetail> GetTVShowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var show =
                    await
                    ctx
                    .TVShows
                    .Where(c => c.Id == id)
                    .SingleOrDefaultAsync(c => c.Id == id);
                if (show is null)
                {
                    return null;
                }

                return new TVShowDetail
                {
                    Id = show.Id,
                    Title = show.Title,
                    ReleaseDate = show.ReleaseDate,
                    Genre = show.Genre,
                    Description = show.Description,
                    MainCharacters = show.MainCharacters,
                };
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                TVShow tvShow = await ctx.TVShows.FindAsync(id);
                if (tvShow is null)
                {
                    return false;
                }
                ctx.TVShows.Remove(tvShow);
                return await ctx.SaveChangesAsync()==1;
            }
        }
    }
}




