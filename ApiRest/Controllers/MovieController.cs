namespace ApiRest.Controllers
{
    using System.Web.Http;
    using UseCase.Movie;


    public class MovieController : ApiController
    {
        public MovieUseCase movieUseCase { get; set; }

        public MovieController(MovieUseCase movieUseCase)
        {
            this.movieUseCase = movieUseCase;
        }

        [HttpGet]
        [Route("api/movie/")]
        public IHttpActionResult GetMovie()
        {
            return Ok(movieUseCase.getAllMovies());
        }

    }
}
