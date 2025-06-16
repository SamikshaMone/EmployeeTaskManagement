using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagementSystem.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string AssignedTo { get; set; }  // Employee Email or UserId

        public string AssignedBy { get; set; }  // Manager Email or UserId

        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed

        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        public DateTime? DueDate { get; set; }
    }
}
