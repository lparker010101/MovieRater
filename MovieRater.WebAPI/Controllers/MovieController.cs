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
    public class MovieController : ApiController
    {
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }

        public async Task<IHttpActionResult> Put(MovieEdit movie, int editMovieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateMovieService();
            if (await service.Put(movie, editMovieId))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }

    //
}
