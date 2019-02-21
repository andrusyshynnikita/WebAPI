using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using Dapper.Contrib;

namespace TestProject.WebApp.RepositoryDapper
{
    public class TaskRepository : ITaskRepository<TaskModel>
    {
        string connectionString =  ConfigurationManager.ConnectionStrings["BookContext"].ConnectionString;


        public TaskRepository()
        {
           
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TaskModel>("SELECT * FROM Users WHERE User_Id = @id", new { id }).ToList();
            }
        }

        public string Create(HttpRequest httpRequest)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                //  db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
                return "hello";
            }
        }

        public string Update(HttpRequest httpRequest)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
             //   db.Execute(sqlQuery, user);
            }
            return "hello";
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public HttpResponseMessage DownloadAudioFile(int id)
        {
            throw new NotImplementedException();
        }
    }
}