using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestProject.WebApp.Interface
{
   public interface ITaskRepository<T> where T : class
    {
        IEnumerable<T> GetTasks(string id);
        string Create(HttpRequest httpRequest);
        string Update(HttpRequest httpRequest);
        void Delete(int id);
        HttpResponseMessage DownloadAudioFile(int id);
    }

}
