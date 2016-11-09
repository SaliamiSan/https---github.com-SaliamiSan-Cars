using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarRent
{
    using System.Web.Http.Dependencies;
    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using System.Web.Mvc;

    using CarRent.App_Start;

    using Infrastruction.DomainObjects;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Mvc;

    using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.AddODataQueryFilter();
            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityResolver(container);
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Car>("Cars");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class UnityResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
