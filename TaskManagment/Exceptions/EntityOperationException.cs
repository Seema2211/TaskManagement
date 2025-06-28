namespace TaskManagement.Exceptions
{
    /// <summary>
    /// Exception used for signaling entity operation failures.
    /// </summary>
    public class EntityOperationException : Exception
    {
        public EntityOperationException(string message) : base(message) { }
    }
}
