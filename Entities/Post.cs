namespace Entities;

public class Post(string title, string content, int userId)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public int UserId { get; set; } = userId;
    public int Location { get; set; }
}