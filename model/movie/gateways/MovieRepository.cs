namespace Model.Movie.Gateways
{
    using System.Collections.Generic;


    public interface MovieRepository
    {
        List<Movie> getAllMovies();
    }
}
