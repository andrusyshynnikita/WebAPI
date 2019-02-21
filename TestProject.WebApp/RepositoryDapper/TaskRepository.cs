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
using Dapper.Contrib.Extensions;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TestProject.WebApp.RepositoryDapper
{
    public class TaskRepository : ITaskRepository<TaskModel>
    {
        string connectionString =  ConfigurationManager.ConnectionStrings["BookContext"].ConnectionString;
        private TaskModel _taskModel;
        private string _filename;

        public TaskRepository()
        {
           
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
              var res=  SqlMapperExtensions.GetAll<TaskModel>(db).Where(x => x.User_Id == id);
                return res;
            }
        }

        public string Create(HttpRequest httpRequest)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                try
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];

                            _filename = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + _filename);

                            postedFile.SaveAs(filePath);

                        }
                    }

                    if (httpRequest["TaskModel"] != null)
                    {
                        var postedForm = httpRequest.Form["TaskModel"];
                        _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);
                        SqlMapperExtensions.Insert(db, _taskModel);
                    }
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }

                return "no files";
            }
        }

        public string Update(HttpRequest httpRequest)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                try
                {
                    if (httpRequest.Files.Count > 0)
                    {
                        foreach (string file in httpRequest.Files)
                        {
                            var postedFile = httpRequest.Files[file];

                            var fileName = postedFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                            postedFile.SaveAs(filePath);
                        }
                    }

                    if (httpRequest["TaskModel"] != null)
                    {
                        var postedForm = httpRequest.Form["TaskModel"];
                        _taskModel = JsonConvert.DeserializeObject<TaskModel>(postedForm);
                        SqlMapperExtensions.Update(db, _taskModel);
                    }
                }

                catch (Exception exception)
                {
                    return exception.Message;
                }

                return "no files";
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                TaskModel task = SqlMapperExtensions.Get<TaskModel>(db, id);

                if (task.AudioFileName != null)
                {
                    var fileName = task.AudioFileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

                    File.Delete(filePath);
                }

                if (task != null)
                {
                    SqlMapperExtensions.Delete<TaskModel>(db, task);
                    
                }
            }
        }

        public HttpResponseMessage DownloadAudioFile(int id)
        {
            IDbConnection db = new SqlConnection(connectionString);

            var task = SqlMapperExtensions.Get<TaskModel>(db, id); 

            var fileName = task.AudioFileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();

            var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + fileName);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Content = new StreamContent(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/3gpp");

            return response;
        }
    }
}