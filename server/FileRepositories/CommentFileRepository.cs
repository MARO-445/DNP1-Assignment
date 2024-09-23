using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentFileRepository : ICommentRepository
{
    private const string filePath = "comments.json";
    private List<Comment> comments = JsonSerializer.Deserialize<List<Comment>>(File.ReadAllText(filePath)) ?? [];
    
    
    public CommentFileRepository()
    {
        
    }
    
    public async Task<Comment> AddAsync(Comment comment)
    {
        comment.Id = comments.Any()
            ? comments.Max(p => p.Id) + 1
            : 1;
        comments.Add(comment);
        await Save();
        return comment;
    }
    
    public async Task UpdateAsync(Comment comment)
    {
        Comment? existingComment = comments.SingleOrDefault(p => p.Id == comment.Id);
        if (existingComment is null)
        {
            throw new InvalidOperationException(
                $"Comment with ID {comment.Id} not found");
        }
        
        comments.Remove(existingComment);
        comments.Add(comment);
        
        await Save();
    }

    public async Task DeleteAsync(int id)
    {
        Comment? commentToRemove = comments.SingleOrDefault(p => p.Id == id);
        if (commentToRemove is null)
        {
            throw new InvalidOperationException(
                $"Comment with ID {id} not found");
        }

        comments.Remove(commentToRemove);
        await Save();
    }

    public async Task<Comment> GetSingleAsync(int id)
    {
        Comment? commentToReturn = comments.SingleOrDefault(p => p.Id == id);
        if (commentToReturn is null)
        {
            throw new InvalidOperationException(
                $"Comment with ID {id} not found");
        }
        
        await Save();
        return commentToReturn;
    }

    public IQueryable<Comment> GetMany()
    {
        return comments.AsQueryable();
    }
    
    private async Task Save() {
        try {
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(comments));
        }
        catch (Exception) {
            throw new IOException("Couldn't save changes!");
        }
    }
}