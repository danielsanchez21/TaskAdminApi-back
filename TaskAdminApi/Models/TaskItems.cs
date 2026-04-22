namespace TaskAdminApi.Models;

public class TaskItems
{
    public int Id { get; set; }
    public string Title { set; get; }
    public string Description { set; get; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }
    
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    
}