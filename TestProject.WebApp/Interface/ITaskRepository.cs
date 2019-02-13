using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.WebApp.Interface
{
    interface ITaskRepository<T> where T : class
    {
        IEnumerable<T> GetTasks(string id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

}
