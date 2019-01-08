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
        public long User_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public TaskInfo(int id,long user_id, string taskName, string taskDescription, bool taskStatus)
        {
            Id = id;
            User_Id = user_id;
            Title = taskName;
            Description = taskDescription;
            Status = taskStatus;
        }

        public TaskInfo()
        {

        }
    }
}
