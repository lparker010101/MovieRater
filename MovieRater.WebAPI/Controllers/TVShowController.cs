using Microsoft.AspNet.Identity;
using MovieRater.Models.TVShowModels;
using MovieRater.Services.TVShowServices;
using System;
using System.Collections;
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
            var tvs = new TVShowService(userId);
            return tvs;
        }

        [HttpPost]
        public async Task<IHttpActionResult> TVShow(TVShowCreate tvshow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateTvShowService();
            if (await service.CreateTVShow(tvshow))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllTVShows()
        {
            TVShowService tvShowServices = CreateTvShowService();
            var tvShow = await tvShowServices.GetTVShows();
            return Ok(tvShow);
        }

        // GET TVShow By Id (Required)
        [HttpGet]
        public async Task<IHttpActionResult> GetTVShowById(int id)
        {
            TVShowService tvShowServices = CreateTvShowService();
            var tvShow = await tvShowServices.GetTVShowById(id);
            return Ok(tvShow);
        }
    }
}
