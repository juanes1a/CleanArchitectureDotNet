namespace UseCase.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using UseCase.Movie;

    public class UseCaseInstaller : IWindsorInstaller
    {
        public UseCaseInstaller()
        {
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                    Component.For<MovieUseCase>().Named("movieUseCase").LifestylePerWebRequest()
                );
        }
    }
}
