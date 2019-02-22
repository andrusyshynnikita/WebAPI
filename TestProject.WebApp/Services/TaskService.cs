using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;

namespace TestProject.WebApp.Services
{
    public class TaskService : ITaskService
    {
        private TaskContext _db = new TaskContext();
        private ITaskRepository<TaskModel> _taskRepository;
        public TaskService(ITaskRepository<TaskModel> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
           var tasks= _taskRepository.GetTasks(id);

            return tasks;
        }

        public void Create(TaskModel taskModel, byte[] audioFile, string audioFilePath)
        {
            _taskRepository.Create(taskModel);
            if (taskModel.AudioFileName != null)
            {
                File.WriteAllBytes(audioFilePath, audioFile);
            }
        }

        public void Update(TaskModel taskModel, byte[] audioFile, string audioFilePath)
        {
            _taskRepository.Update(taskModel);

            if (taskModel.AudioFileName != null && audioFile!=null)
            {
                File.WriteAllBytes(audioFilePath, audioFile);
            }
        }

        public void Delete(int id)
        {
            TaskModel taskModel = _taskRepository.Delete(id);

            if (taskModel.AudioFileName != null)
            {
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + taskModel.AudioFileName);

                File.Delete(filePath);
            }
        }

        public TaskModel DownloadAudioFile(int id)
        {
           TaskModel taskModel= _taskRepository.DownloadAudioFile(id);

            return taskModel;

        }

    }
}