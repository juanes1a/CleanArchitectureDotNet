namespace EntityRepository.Movie
{
    using EntityRepositoryCommons;
    using Model.Movie.Gateways;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class MovieAdapter : BaseRepository<MovieData, Model.Movie.Movie>, MovieRepository
    {
        public MovieAdapter(DbContext context) : base(context)
        {
        }

        public List<Model.Movie.Movie> getAllMovies()
        {
            return base.toList(base.Get());
        }
    }
}
