using TaskStatus = SprintManager.Models.TaskStatus;

namespace SprintManager.DTO;

public class TaskStatusDto
{
    public int TaskId { get; set; }
    public TaskStatus Status { get; set; }
}