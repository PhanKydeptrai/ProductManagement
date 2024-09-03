namespace ProductManagement.Domain.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserMail { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
