using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Exceptions;
using TaskManagement.Models;

namespace TaskManagement.Repositories
{
    /// <summary>
    /// Implements data access logic for tasks using EF Core.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;
        private readonly ILogger<TaskRepository> _logger;

        public TaskRepository(TaskDbContext context, ILogger<TaskRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all tasks.");
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Fetching task with ID: {TaskId}", id);
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                _logger.LogWarning("Failed to add task: {@Task}", task);
                throw new EntityOperationException("Task could not be added.");
            }
            _logger.LogInformation("Task added successfully: {@Task}", task);
            return task;
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                _logger.LogWarning("Failed to update task: {@Task}", task);
                throw new EntityOperationException("Task update failed.");
            }
            _logger.LogInformation("Task updated successfully: {@Task}", task);
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                _logger.LogWarning("Failed to delete task: {@Task}", task);
                throw new EntityOperationException("Task deletion failed.");
            }
            _logger.LogInformation("Task deleted successfully: {@Task}", task);
        }
    }
}
