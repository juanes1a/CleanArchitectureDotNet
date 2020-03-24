namespace EntityRepository.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using EntityRepository.Movie;
    using Model.Movie.Gateways;
    using System.Data.Entity;

    public class EntityRepositoryInstaller : IWindsorInstaller
    {
        public DbContext context { get; set; }
        public EntityRepositoryInstaller(DbContext context)
        {
            this.context = context;
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<MovieRepository>()
                    .ImplementedBy<MovieAdapter>()
                    .Named("movieRepository")
                    .DependsOn(Dependency.OnValue("context", this.context))
                    .LifestylePerWebRequest()
                );
        }
    }
}
