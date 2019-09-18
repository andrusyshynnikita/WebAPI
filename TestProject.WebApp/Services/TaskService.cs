using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Interface;
using TestProject.WebApp.Models;
using TestProject.WebApp.ViewModel;

namespace TestProject.WebApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasks(string id)
        {
            IEnumerable<TaskViewModel> tasksviewModel;

            var tasksModel = _taskRepository.GetAllUserTasks(id);
            tasksviewModel = _mapper.Map<IEnumerable<TaskModel>, IEnumerable<TaskViewModel>>(tasksModel);

            return tasksviewModel;
        }

        public async Task<ResponseViewModel> Create(TaskViewModel taskViewModel)
        {
            var responseViewModel = new ResponseViewModel();
            var taskModel = _mapper.Map<TaskViewModel, TaskModel>(taskViewModel);
            _taskRepository.Add(taskModel);
            try
            {
                if (taskViewModel.AudioFileContent != null)
                {
                    string audioFilePath = HttpContext.Current.Server.MapPath("~/Uploads/" + taskModel.AudioFileName);
                    File.WriteAllBytes(audioFilePath, taskViewModel.AudioFileContent);
                }
                responseViewModel.IsSuccess = true;

                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel.Message = ex.Message;

                return responseViewModel;
            }
        }

        public async Task<ResponseViewModel> Update(TaskViewModel taskViewModel)
        {
            var responseViewModel = new ResponseViewModel();

            var taskModel = _mapper.Map<TaskViewModel, TaskModel>(taskViewModel);
            _taskRepository.Edit(taskModel);

            try
            {
                if (taskViewModel.AudioFileContent != null)
                {
                    string audioFilePath = HttpContext.Current.Server.MapPath("~/Uploads/" + taskModel.AudioFileName);
                    File.WriteAllBytes(audioFilePath, taskViewModel.AudioFileContent);
                }

                responseViewModel.IsSuccess = true;

                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel.Message = ex.Message;

                return responseViewModel;
            }
        }

        public async Task<ResponseViewModel> Delete(int id)
        {
            var responseViewModel = new ResponseViewModel();

            _taskRepository.Delete(id);

            TaskModel task = _taskRepository.GetItem(id);

            try
            {
                if (task.AudioFileName != null)
                {
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + task.AudioFileName);

                    File.Delete(filePath);
                }

                responseViewModel.IsSuccess = true;

                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel.Message = ex.Message;

                return responseViewModel;
            }
        }

        public async Task<TaskViewModel> DownloadAudioFile(int id)
        {
            TaskModel taskModel = _taskRepository.GetItem(id);
            var taskViewModel = _mapper.Map<TaskModel, TaskViewModel>(taskModel);

            if (!string.IsNullOrEmpty(taskModel.AudioFileName))
            {
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + taskViewModel.AudioFileName);
                taskViewModel.AudioFileContent = File.ReadAllBytes(filePath);
            }

            return taskViewModel;
        }

    }
}