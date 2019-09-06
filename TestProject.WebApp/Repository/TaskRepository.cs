using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Repository
{
    public class TaskRepository : BaseRepository<TaskModel> ,ITaskRepository
    {

        public IEnumerable<TaskModel> GetAllUserTasks(string userId)
        {
            IEnumerable<TaskModel> userTasks = GetAll().Where(x => x.User_Id == userId);

            return userTasks;
        }
    }
}