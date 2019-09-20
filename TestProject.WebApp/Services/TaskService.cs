using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestProject.WebApp.EF;
using TestProject.WebApp.Helpers;
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

        public async Task<ResponseViewModel> CreateOrUpdateTask(TaskViewModel taskViewModel)
        {
            var responseViewModel = new ResponseViewModel();

            var taskModel = _mapper.Map<TaskViewModel, TaskModel>(taskViewModel);

            _taskRepository.AddOrUpdate(taskModel);

            responseViewModel.IsSuccess = true;

            if (!string.IsNullOrEmpty(taskViewModel.AudioFileName) && taskViewModel.AudioFileContent != null)
            {
                responseViewModel.IsSuccess = await StorageHelper.WriteByteToFileAsync(taskViewModel.AudioFileName, taskViewModel.AudioFileContent);
            }

            return responseViewModel;
        }

        public async Task<ResponseViewModel> Delete(int id)
        {
            var responseViewModel = new ResponseViewModel();

            TaskModel task = _taskRepository.GetItem(id);
            _taskRepository.Delete(id);
            responseViewModel.IsSuccess = true;

            if (!string.IsNullOrEmpty(task?.AudioFileName))
            {
                responseViewModel.IsSuccess = await StorageHelper.DeleteFile(task.AudioFileName);
            }

            return responseViewModel;
        }

        public async Task<TaskViewModel> DownloadAudioFile(int id)
        {
            TaskModel taskModel = _taskRepository.GetItem(id);
            var taskViewModel = _mapper.Map<TaskModel, TaskViewModel>(taskModel);

            if (!string.IsNullOrEmpty(taskModel.AudioFileName))
            {
                taskViewModel.AudioFileContent = await StorageHelper.ReadFileAsync(taskViewModel.AudioFileName);
            }

            return taskViewModel;
        }

    }
}