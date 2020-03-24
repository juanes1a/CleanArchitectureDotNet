namespace ApiRest.Windsor
{
    using Castle.Windsor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    public class WindsorDependencyResolver : IDependencyResolver
    {

        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        public object GetService(Type serviceType)
        {
            return this.container.Kernel.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!this.container.Kernel.HasComponent(serviceType))
            {
                return new object[0];
            }

            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

    }
}