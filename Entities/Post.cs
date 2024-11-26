
namespace Entities;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    private Post() { } // For EF Core
    public Post(string title, string content, int userId)
    {
        Title = title;
        Content = content;
        UserId = userId;
    }
}
