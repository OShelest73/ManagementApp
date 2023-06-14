namespace ManagementAppLibrary.Models;

public class UserModel
{
    public string EmailAdress { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Category { get; set; }
    public int? TaskId { get; set; } = null;
}
