using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestProject.WebApp.Interface
{
    interface ITaskRepository<T> where T : class
    {
        IEnumerable<T> GetTasks(string id);
        string Create(HttpRequest httpRequest);
        void Update(T item);
        void Delete(int id);
    }

}
