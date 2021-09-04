using Microsoft.AspNet.Identity;
using MovieRater.Models.TVShowModels;
using MovieRater.Services.TVShowServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieRater.WebAPI.Controllers
{
    public class TvShowController : ApiController
    {
        private TVShowService CreateTvShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var tvShowService = new TVShowService(userId);
            return tvShowService;
        }

        //public async Task<IHttpActionResult> Put(TvShowEdit tvShow, int editTvShowId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var service = CreateTvShowService();
        //    if (await service.Put(tvShow, editTvShowId))
        //    {
        //        return Ok();
        //    }
        //    return InternalServerError();
        //}
        public async Task<IHttpActionResult> Delete(int id)
        {
            var service = CreateTvShowService();
            if (await service.Delete(id))
            {
                return Ok();
            }

            return InternalServerError();

        }
    }
}
