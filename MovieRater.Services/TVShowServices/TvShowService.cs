using MovieRater.Models.TVShowModels;
using MovieRater.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Services.TVShowServices
{
    public class TvShowService
    {
        private readonly Guid _id;

        public TvShowService(Guid id)
        {
            _id = id;
        }

        public async Task<bool> Put(TvShowEdit tvShow, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldTvShowData = await ctx.TvShows.FindAsync(id);
                if (oldTvShowData is null)
                {
                    return false;
                }

                oldTvShowData.Id = tvShow.Id;
                oldTvShowData.Title = tvShow.Title;
                oldTvShowData.Text = tvShow.Text;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
