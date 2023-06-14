namespace ManagementAppLibrary.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Task { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string AuthorId { get; set; } //id создавшего таску
    public string Category { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public bool Archived { get; set; } = false;
}
