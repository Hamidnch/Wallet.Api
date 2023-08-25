﻿namespace Wallet.Application.Features.Wallet.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T?>> GetAllAsync();
    Task AddAsync(T? entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T? entity);
}