using EmployeeTaskManagementSystem.Models;

namespace EmployeeTaskManagementSystem.Services.Interfaces
{
    public interface ITaskService
    {
        Task AssignTaskAsync(TaskModel task);
        Task<List<TaskModel>> GetAllTasksAsync();
        Task<bool> UpdateTaskAsync(int id, TaskModel task);
    }
}
