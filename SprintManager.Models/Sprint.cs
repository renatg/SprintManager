namespace SprintManager.Models;

public class Sprint
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartData { get; set; }
    public DateTime EndDate { get; set; }
    public string Purpose { get; set; }
    public virtual List<Task> Tasks { get; set; }
}