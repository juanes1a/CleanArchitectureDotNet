namespace ApiRest
{
    using ApiRest.Windsor;
    using Castle.MicroKernel.Lifestyle;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using EntityRepository.Installer;
    using System.Configuration;
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using UseCase.Installer;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeIoC(GlobalConfiguration.Configuration);
        }

        public static void InitializeIoC(HttpConfiguration configuration)
        {
            var windsor = Ragolo.Core.IoC.IocHelper.Instance;
            var contenedor = windsor.GetContainer();

            var context = new DbContext(ConfigurationManager.ConnectionStrings["CinemaConnectionString"].ToString());

            windsor.Install(new EntityRepositoryInstaller(context));
            windsor.Install(new UseCaseInstaller());
            windsor.Install(new ApiRestInstaller());

            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(contenedor.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            contenedor.Kernel.Resolver.AddSubResolver(new CollectionResolver(contenedor.Kernel, true));
            contenedor.BeginScope();
            var dependencyResolver = new WindsorDependencyResolver(contenedor);
            configuration.DependencyResolver = dependencyResolver;
        }
    }
}
