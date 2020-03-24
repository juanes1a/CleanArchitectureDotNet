using System.Collections.Generic;

namespace model.movie.gateways
{
    public interface MovieRepository
    {
        List<Movie> getAllMovies();
    }
}
