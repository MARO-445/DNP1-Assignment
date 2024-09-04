﻿using Entities;

namespace RepositoryContracts;

public interface IPostRepository
{
    Task<Post> AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Post post);
    Task<Post> GetSingleAsync(Post post);
    IQueryable<Post> GetMany();
}