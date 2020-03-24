namespace UseCase.Movie
{
    using Model.Movie.Gateways;
    using System.Collections.Generic;

    public class MovieUseCase
    {
        private MovieRepository movieRepository { set; get; }

        public MovieUseCase(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public List<Model.Movie.Movie> getAllMovies()
        {
            return movieRepository.getAllMovies();
        }
    }
}
