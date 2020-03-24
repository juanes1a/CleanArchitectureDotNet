using model.movie;
using model.movie.gateways;
using System.Collections.Generic;

namespace use_caswe.movie
{
    public class MovieUseCase
    {
        private MovieRepository repository { set; get; }

        public MovieUseCase(MovieRepository movieRepository)
        {
            this.repository = movieRepository;
        }

        public List<Movie> getAllMovies()
        {
            return repository.getAllMovies();
        } 
    }
}
