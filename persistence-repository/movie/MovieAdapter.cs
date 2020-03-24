using model.movie;
using model.movie.gateways;
using System.Collections.Generic;

namespace persistence_repository.movie
{
    public class MovieAdapter : MovieRepository
    {
        public MovieAdapter() { }
        public List<Movie> getAllMovies()
        {
            var list = new List<Movie>();
            list.Add(new Movie("1","Duro de Matar"));
            return list;
        }
    }
}
