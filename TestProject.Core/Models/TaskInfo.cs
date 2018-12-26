using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestProject.Core.Models
{
    public class TaskInfo

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public TaskInfo(int _id,string _taskName, string _taskDescription, bool _taskStatus)
        {
            Id = _id;
            Title = _taskName;
            Description = _taskDescription;
            Status = _taskStatus;
        }

        public TaskInfo()
        {

        }
    }
}
