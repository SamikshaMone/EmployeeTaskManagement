using EmployeeTaskManagementSystem.Models;
using EmployeeTaskManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagementSystem.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignTaskAsync(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<bool> UpdateTaskAsync(int id, TaskModel updatedTask)
        {
            var existing = await _context.Tasks.FindAsync(id);
            if (existing == null) return false;

            existing.Title = updatedTask.Title;
            existing.Description = updatedTask.Description;
            existing.Status = updatedTask.Status;
            existing.DueDate = updatedTask.DueDate;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
