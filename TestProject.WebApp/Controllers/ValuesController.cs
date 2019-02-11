using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestProject.WebApp.EF;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Controllers
{
    public class ValuesController : ApiController
    {
        TaskContext db = new TaskContext();
        // GET api/values
        public IEnumerable<TaskModel> GetTasks()
        {
           var d= db.Tasks;
            return d;
        }

        // GET api/values/5
        public TaskModel GetTask(int id)
        {
            TaskModel taskModel = db.Tasks.Find(id);
            return taskModel;
        }

        public void DeleteBook(int id)
        {
            TaskModel book = db.Tasks.Find(id);
            if (book != null)
            {
                db.Tasks.Remove(book);
                db.SaveChanges();
            }
        }

        // POST api/values
        public bool PostTask([FromBody]TaskModel value)
        {
            db.Tasks.Add(value);
            if (db.SaveChanges() != 0)
            {
                return true;
            }
            return false;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]TaskModel value)
        {
            if (id == value.Id)
            {
                db.Entry(value).State = EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
