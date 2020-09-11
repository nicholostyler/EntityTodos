using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoLibrary.Models
{
    public class Task
    {
        public Task(int iD, string description, DateTime dueDate, string priority)
        {
            Id = iD;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }

        public Task()
        {

        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }
    }

    public enum TaskPriority
    {
        High,
        Medium,
        Low
    }
}
