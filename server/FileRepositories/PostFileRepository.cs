using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostFileRepository : IPostRepository
{
    private const string filePath = "posts.json";
    private List<Post> posts = JsonSerializer.Deserialize<List<Post>>(File.ReadAllText(filePath)) ?? [];
    
    
    public PostFileRepository()
    {
        
    }
    
    public async Task<Post> AddAsync(Post post)
    {
        post.Id = posts.Any()
            ? posts.Max(p => p.Id) + 1
            : 1;
        posts.Add(post);
        await Save();
        return post;
    }
    
    public async Task UpdateAsync(Post post)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost is null)
        {
            throw new InvalidOperationException(
                $"Post with ID {post.Id} not found");
        }
        
        posts.Remove(existingPost);
        posts.Add(post);
        
        await Save();
    }

    public async Task DeleteAsync(int id)
    {
        Post? postToRemove = posts.SingleOrDefault(p => p.Id == id);
        if (postToRemove is null)
        {
            throw new InvalidOperationException(
                $"Post with ID {id} not found");
        }

        posts.Remove(postToRemove);
        await Save();
    }

    public async Task<Post> GetSingleAsync(int id)
    {
        Post? postToReturn = posts.SingleOrDefault(p => p.Id == id);
        if (postToReturn is null)
        {
            throw new InvalidOperationException(
                $"Post with ID {id} not found");
        }
        
        await Save();
        return postToReturn;
    }

    public IQueryable<Post> GetMany()
    {
        return posts.AsQueryable();
    }
    
    private async Task Save() {
        try {
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(posts));
        }
        catch (Exception) {
            throw new IOException("Couldn't save changes!");
        }
    }
}