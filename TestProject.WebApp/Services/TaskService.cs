﻿using System;
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
        private ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskModel> GetTasks(string id)
        {
            var tasks = _taskRepository.GetAllUserTasks(id);

            return tasks;
        }

        public void Create(TaskModel taskModel)
        {
            //TODO: create Mapper
            _taskRepository.Add(taskModel);
            //if (taskModel.AudioFileContent != null)
            //{
            //    string audioFilePath  = HttpContext.Current.Server.MapPath("~/Uploads/" + taskModel.AudioFileName);
            //    File.WriteAllBytes(audioFilePath, taskModel.AudioFileContent);
            //}
        }

        public void Update(TaskModel taskModel, byte[] audioFile, string audioFilePath)
        {
            _taskRepository.Edit(taskModel);

            if (taskModel.AudioFileName != null && audioFile != null)
            {
                File.WriteAllBytes(audioFilePath, audioFile);
            }
        }

        public void Delete(int id)
        {
            _taskRepository.Delete(id);

            TaskModel task = _taskRepository.GetItem(id);

            if (task.AudioFileName != null)
            {
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + task.AudioFileName);

                File.Delete(filePath);
            }
        }

        public TaskModel DownloadAudioFile(int id)
        {
            TaskModel taskModel = _taskRepository.GetItem(id);

            return taskModel;

        }

    }
}