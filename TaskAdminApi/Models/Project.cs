namespace TaskAdminApi.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<TaskItems> Tasks { set; get; }
}