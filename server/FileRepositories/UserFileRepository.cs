using System.Text.Json;
using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class UserFileRepository : IUserRepository
{
    private const string filePath = "users.json";
    private List<User> users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filePath)) ?? [];
    
    
    public UserFileRepository()
    {
        
    }
    
    public async Task<User> AddAsync(User user)
    {
        user.Id = users.Any()
            ? users.Max(p => p.Id) + 1
            : 1;
        users.Add(user);
        await Save();
        return user;
    }
    
    public async Task UpdateAsync(User user)
    {
        User? existingUser = users.SingleOrDefault(p => p.Id == user.Id);
        if (existingUser is null)
        {
            throw new InvalidOperationException(
                $"User with ID {user.Id} not found");
        }
        
        users.Remove(existingUser);
        users.Add(user);
        
        await Save();
    }

    public async Task DeleteAsync(int id)
    {
        User? userToRemove = users.SingleOrDefault(p => p.Id == id);
        if (userToRemove is null)
        {
            throw new InvalidOperationException(
                $"User with ID {id} not found");
        }

        users.Remove(userToRemove);
        await Save();
    }

    public async Task<User> GetSingleAsync(int id)
    {
        User? userToReturn = users.SingleOrDefault(p => p.Id == id);
        if (userToReturn is null)
        {
            throw new InvalidOperationException(
                $"User with ID {id} not found");
        }
        
        await Save();
        return userToReturn;
    }

    public IQueryable<User> GetMany()
    {
        return users.AsQueryable();
    }
    
    private async Task Save() {
        try {
            await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(users));
        }
        catch (Exception) {
            throw new IOException("Couldn't save changes!");
        }
    }
}