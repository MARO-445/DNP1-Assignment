namespace Entities;

public class Comment(string content, string userId, int location)
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int Location { get; set; }
}