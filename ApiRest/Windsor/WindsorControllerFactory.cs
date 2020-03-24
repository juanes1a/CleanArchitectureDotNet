﻿namespace ApiRest.Windsor
{
    using Castle.MicroKernel;
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;


    public class WindsorControllerFactory : DefaultControllerFactory
    {

        private readonly IKernel kernel;
        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public override void ReleaseController(IController controller)
        {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            return (IController)kernel.Resolve(controllerType);

    }
}