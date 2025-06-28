using TaskManagement.Models;

namespace TaskManagement.Services
{
    /// <summary>
    /// Business logic interface for task management.
    /// </summary>
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> CreateTaskAsync(TaskItem task);
        Task<bool> UpdateTaskAsync(int id, TaskItem updatedTask);
        Task<bool> DeleteTaskAsync(int id);
    }
}
