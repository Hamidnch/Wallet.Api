using Microsoft.EntityFrameworkCore;
using Wallet.Application.Features.Wallet.Repositories;
using Wallet.Domain.Common;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly WalletDbContext Context;
    protected readonly DbSet<T> DbSet;

    public Repository(WalletDbContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task AddAsync(T? entity)
    {
        if (entity != null)
            await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T? entity)
    {
        if (entity != null)
            DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}