using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestProject.Core.Models
{
    class TaskInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }

    }
}
