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
    }


}
