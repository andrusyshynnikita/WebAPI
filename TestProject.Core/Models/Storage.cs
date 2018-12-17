using System;
using System.Collections.Generic;
using MvvmCross.Core;
using MvvmCross.ViewModels;
using TestProject.Core.Models;
using System.Collections.ObjectModel;


namespace TestProject.Core.Models
{
   public class Storage: MvxViewModel
    {
        private ObservableCollection<TaskInfo> _taskStorage;

        public Storage()
        {
            TaskStorage = new ObservableCollection<TaskInfo>();
            TaskStorage.Add(new TaskInfo { Id = 1, TaskName = "Attemp Dropbox DBX", TaskDescription = "do something", TaskStatus = true });
            TaskStorage.Add(new TaskInfo { Id = 2, TaskName = "Build Xamarin Component", TaskDescription = "do something", TaskStatus = true });
            TaskStorage.Add(new TaskInfo { Id = 3, TaskName = "Make monkeys dance!", TaskDescription = "do something", TaskStatus = true });
            
            
        }

        public ObservableCollection<TaskInfo> TaskStorage
        {
            get { return _taskStorage; }
            set
            {
                _taskStorage = value;
                RaisePropertyChanged(() => TaskStorage);
            }
            
        }
        
        
    }
}
