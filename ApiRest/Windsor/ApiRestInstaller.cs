namespace ApiRest.Windsor
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;

    public class ApiRestInstaller : IWindsorInstaller
    {
        public ApiRestInstaller() { }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               Classes.
                   FromThisAssembly().
                   BasedOn<IController>(). //MVC
                   If(c => c.Name.EndsWith("Controller")).
                   LifestylePerWebRequest());

            container.Register(
                Classes.
                    FromThisAssembly().
                    BasedOn<IHttpController>(). //Web API
                    If(c => c.Name.EndsWith("Controller")).
                    LifestylePerWebRequest());
        }
    }
}