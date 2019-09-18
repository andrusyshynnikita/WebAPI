using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using TestProject.WebApp.DependencyResolver;
using TestProject.WebApp.Interface;
using TestProject.WebApp.MapperProfiles;
using TestProject.WebApp.Models;
using TestProject.WebApp.Services;
using Unity;
using Unity.Lifetime;

namespace TestProject.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterSingleton<ITaskService, TaskService>();
            // container.RegisterType<ITaskRepository<TaskModel>, TestProject.WebApp.RepositoryDapper.TaskRepository>(new HierarchicalLifetimeManager());
            container.RegisterSingleton<ITaskRepository, TestProject.WebApp.Repository.TaskRepository>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            container.RegisterInstance(mapper);
            config.DependencyResolver = new UnityResolver(container);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }


    }
}
