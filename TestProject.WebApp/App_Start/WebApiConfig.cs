using System.Web.Http;
using TestProject.WebApp.DependencyResolver;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using Unity;
using Unity.Lifetime;

namespace TestProject.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
       
            var container = new UnityContainer();

          //  container.RegisterType<ITaskRepository<TaskModel>, TestProject.WebApp.RepositoryDapper.TaskRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaskRepository<TaskModel>, TestProject.WebApp.Repository.TaskRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
