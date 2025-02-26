namespace ProjectManagementPlatform.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; } // Relacionamento com o usuário
    }

    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }
}