using SprintManager.DTO.Auth;
using SprintManager.Models;
using TaskStatus = SprintManager.Models.TaskStatus;

namespace SprintManager.DTO;

public class TaskDto
{
    public int Id { get; set; }
    public TaskType IssueType { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int AssigneeId { get; set; }
    public UserDto Assignee { get; set; }
    public int Priority { get; set; }
    public int StoryPointEstimate { get; set; }
    public int SprintId { get; set; }
}