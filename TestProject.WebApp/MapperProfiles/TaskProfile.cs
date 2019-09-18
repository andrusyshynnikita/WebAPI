using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.WebApp.Models;
using TestProject.WebApp.ViewModel;

namespace TestProject.WebApp.MapperProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskModel, TaskViewModel>();

            CreateMap<TaskViewModel, TaskModel>();
        }
    }
}