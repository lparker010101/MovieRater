using MovieRater.Data;
using System;
using System.Collections.Generic;
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
                return await ctx.SaveChangesAsync() > 1;
            }
        }
    }
}
