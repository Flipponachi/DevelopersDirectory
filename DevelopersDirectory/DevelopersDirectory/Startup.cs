using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevelopersDirectory
{
    using System.Reflection;
    using System.Web.Http;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    /// <summary>
    /// The startup class for a OWIN service.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates a configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = new HttpConfiguration();
            webApiConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "values" });

            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(webApiConfiguration);
        }

        /// <summary>
        /// Creates the kernel.
        /// </summary>
        /// <returns>the newly created kernel.</returns>
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}