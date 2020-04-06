using Castle.Windsor;
using Genesis.Domain;
using Genesis.Repository;
using Genesis.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Genesis
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureWindsor();
        }

        private static void ConfigureWindsor()
        {
            var container = new WindsorContainer()
                .Install(new WebWindsorInstaller());

            GlobalConfiguration.Configuration.DependencyResolver =
                new WindsorDependencyResolver(container);
        }
    }
}
