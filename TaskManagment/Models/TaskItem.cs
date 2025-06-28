namespace TaskManagement.Models
{
    /// <summary>
    /// Represents a task entity.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Unique identifier for the task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title or name of the task.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of the task.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Due date of the task.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Indicates whether the task is completed.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
