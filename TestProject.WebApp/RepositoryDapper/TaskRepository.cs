using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using Dapper.Contrib.Extensions;

namespace TestProject.WebApp.RepositoryDapper
{
    public class TaskRepository : ITaskRepository<TaskModel>
    {

      private string connectionString = ConfigurationManager.ConnectionStrings["BookContext"].ConnectionString;

        public TaskRepository()
        {

        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = SqlMapperExtensions.GetAll<TaskModel>(db).Where(x => x.User_Id == id);

                return res;
            }
        }

        public void Create(TaskModel taskModel)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                SqlMapperExtensions.Insert(db, taskModel);
            }
        }

        public void Update(TaskModel taskModel)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                {
                    SqlMapperExtensions.Update(db, taskModel);
                }
            }
        }

        public TaskModel Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                TaskModel taskModel = SqlMapperExtensions.Get<TaskModel>(db, id);

                if (taskModel != null)
                {
                    SqlMapperExtensions.Delete<TaskModel>(db, taskModel);
                }

                return taskModel;
            }
        }

        public TaskModel DownloadAudioFile(int id)
        {
            IDbConnection db = new SqlConnection(connectionString);

            TaskModel taskModel = SqlMapperExtensions.Get<TaskModel>(db, id);

            return taskModel;
        }
    }
}