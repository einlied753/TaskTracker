using System.Web.Http;
using WebActivatorEx;
using TaskTracker;
using Swashbuckle.Application;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using TaskTracker.DAL;
using SimpleInjector.Lifestyles;
using TaskTracker.Controllers;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace TaskTracker
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IUnitOfWork, UnitOfWork<Context>>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, thisAssembly);

            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "Task Tracker API"))
                .EnableSwaggerUi();

            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
