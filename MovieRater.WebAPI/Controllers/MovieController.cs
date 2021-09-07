using Microsoft.AspNet.Identity;
using MovieRater.Models.MovieModels;
using MovieRater.Services.MovieServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieRater.WebAPI.Controllers
{
    [Authorize]
    public class MovieController : ApiController
    {
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();
            if (await service.Post(movie))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(MovieEdit movie, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();
            if (await service.Put(movie, id))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var service = CreateMovieService();
            if (await service.Delete(id))
            {
                return Ok();
            }

            return InternalServerError();

        }

        public async Task<IHttpActionResult> Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();
            if (await service.Post(movie))
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}
