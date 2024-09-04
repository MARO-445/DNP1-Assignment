﻿using Entities;

namespace RepositoryContracts;

public interface ICommentRepository
{
    Task<Comment> AddAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
    Task<Comment> GetSingleAsync(Comment comment);
    IQueryable<Comment> GetMany();
}