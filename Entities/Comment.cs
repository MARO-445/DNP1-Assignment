
namespace Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int PostId { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public Post Post { get; set; } = null!;

    private Comment() { } // For EF Core
    public Comment(string content, int userId, int postId)
    {
        Content = content;
        UserId = userId;
        PostId = postId;
    }
}
