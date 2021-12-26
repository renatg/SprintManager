using SprintManager.Models.Auth;

namespace SprintManager.Models;

public class Task
{
    public int Id { get; set; }
    public TaskType IssueType { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int AssigneeId { get; set; }
    public virtual User Assignee { get; set; }
    public int Priority { get; set; }
    public int StoryPointEstimate { get; set; }
    public int SprintId { get; set; }
    public virtual Sprint Sprint { get; set; }
}