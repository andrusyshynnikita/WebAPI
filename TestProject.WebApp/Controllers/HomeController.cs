using System.Web.Mvc;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        TaskContext db = new TaskContext();
        ITaskRepository<TaskModel> _taskRepository;

        public HomeController()
        {
        }
        public ActionResult Index()
        {
          //  var a = View(_taskRepository.GetTasks("fds"));

            return View(db.Tasks);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
