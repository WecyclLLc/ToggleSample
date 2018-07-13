using Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace ToggleWeb
{
    public static class UnityConfig
    {
        public class UnityFilterAttributeFilterProvider : FilterAttributeFilterProvider
        {
            private readonly IUnityContainer _container;
            public UnityFilterAttributeFilterProvider(IUnityContainer container)
            {
                _container = container;
            }
            protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
            {
                var attributes = base.GetControllerAttributes(controllerContext, actionDescriptor).ToList();
                foreach (var attribute in attributes)
                {
                    _container.BuildUp(attribute.GetType(), attribute);
                }

                return attributes;
            }

            protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
            {
                var attributes = base.GetActionAttributes(controllerContext, actionDescriptor).ToList();
                foreach (var attribute in attributes)
                {
                    _container.BuildUp(attribute.GetType(), attribute);
                }

                return attributes;
            }
        }
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFeatureOptions, FeatureOptions>();
            container.RegisterType<IFeatureContext, FeatureContext>();

            var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            var provider = new UnityFilterAttributeFilterProvider(container);
            FilterProviders.Providers.Add(provider);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}