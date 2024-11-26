
using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcCommentRepository : ICommentRepository
{
    private readonly AppContext _context;

    public EfcCommentRepository(AppContext context)
    {
        _context = context;
    }

    public async Task<Comment> AddAsync(Comment comment)
    {
        var entityEntry = await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Comment comment)
    {
        if (!(await _context.Comments.AnyAsync(c => c.Id == comment.Id)))
            throw new Exception($"Comment with id {comment.Id} not found");

        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
            throw new Exception($"Comment with id {id} not found");

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

    public IQueryable<Comment> GetMany()
    {
        return _context.Comments.AsQueryable();
    }
}
