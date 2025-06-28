using TaskManagement.Models;
using TaskManagement.Repositories;

namespace TaskManagement.Services
{
    /// <summary>
    /// Implements business logic for task operations.
    /// </summary>
    public class TaskService : ITaskService
        {
            private readonly ITaskRepository _repository;

            public TaskService(ITaskRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<TaskItem>> GetAllTasksAsync() =>
                await _repository.GetAllAsync();

            public async Task<TaskItem?> GetTaskByIdAsync(int id) =>
                await _repository.GetByIdAsync(id);

            public async Task<TaskItem> CreateTaskAsync(TaskItem task) =>
                await _repository.AddAsync(task);

            public async Task<bool> UpdateTaskAsync(int id, TaskItem updatedTask)
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null) return false;

                existing.Title = updatedTask.Title;
                existing.Description = updatedTask.Description;
                existing.DueDate = updatedTask.DueDate;
                existing.IsCompleted = updatedTask.IsCompleted;

                await _repository.UpdateAsync(existing);
                return true;
            }

            public async Task<bool> DeleteTaskAsync(int id)
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null) return false;

                await _repository.DeleteAsync(existing);
                return true;
            }
        }

}
