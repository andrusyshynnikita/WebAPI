using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.WebApp.Models;
using TestProject.WebApp.ViewModel;

namespace TestProject.WebApp.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetTasks(string id);
        Task<ResponseViewModel> Create(TaskViewModel taskViewModel);
        Task<ResponseViewModel> Update(TaskViewModel taskViewModel);
        Task<ResponseViewModel> Delete(int id);
        Task<TaskViewModel> DownloadAudioFile(int id);

    }
}
