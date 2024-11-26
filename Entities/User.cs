
namespace Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    private User() { } // For EF Core
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
