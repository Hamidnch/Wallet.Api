using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Wallet.Application;
using Wallet.Common.CommonHelpers;
using Wallet.Domain.Common;
using Wallet.Persistence.Context;

namespace Wallet.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    //private readonly DbContext _dbContext;
    private readonly WalletDbContext _dbContext;

    public Repository(WalletDbContext dbContext)
    {
        Entities = dbContext.Set<T>();
        _dbContext = dbContext;
    }

    public DbSet<T> Entities { get; }
    public virtual IQueryable<T> Table => Entities;
    public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

    #region Async Method

    public async Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Entities.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Entities.FindAsync(id, cancellationToken);
    }
    public virtual async Task<T?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        return (await Entities.FindAsync(ids, cancellationToken))!;
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        await Entities.AddAsync(entity, cancellationToken);

        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        await Entities.AddRangeAsync(entitiesArray, cancellationToken);
        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        Entities.Update(entity);
        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        Entities.UpdateRange(entitiesArray);
        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        Entities.Remove(entity);
        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        Entities.RemoveRange(entitiesArray);
        if (saveNow)
            await _dbContext.SaveChangesAsync(cancellationToken);
    }
    #endregion

    #region Sync Methods
    public virtual T GetById(params object[] ids)
    {
        return Entities.Find(ids)!;
    }

    public virtual void Add(T entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        Entities.Add(entity);
        if (saveNow)
            _dbContext.SaveChanges();
    }

    public virtual void AddRange(IEnumerable<T> entities, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        Entities.AddRange(entitiesArray);
        if (saveNow)
            _dbContext.SaveChanges();
    }

    public virtual void Update(T entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        Entities.Update(entity);
        if (saveNow)
            _dbContext.SaveChanges();
    }

    public virtual void UpdateRange(IEnumerable<T> entities, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        Entities.UpdateRange(entitiesArray);
        if (saveNow)
            _dbContext.SaveChanges();
    }

    public virtual void Delete(T entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));

        Entities.Remove(entity);
        if (saveNow)
            _dbContext.SaveChanges();
    }

    public virtual void DeleteRange(IEnumerable<T> entities, bool saveNow = true)
    {
        var entitiesArray = entities as T[] ?? entities.ToArray();
        Assert.NotNull(entitiesArray, nameof(entities));

        Entities.RemoveRange(entitiesArray);
        if (saveNow)
            _dbContext.SaveChanges();
    }
    #endregion

    #region Attach & Detach
    public virtual void Detach(T entity)
    {
        Assert.NotNull(entity, nameof(entity));
        var entry = _dbContext.Entry(entity);
        entry.State = EntityState.Detached;
    }

    public virtual void Attach(T entity)
    {
        Assert.NotNull(entity, nameof(entity));
        if (_dbContext.Entry(entity).State == EntityState.Detached)
            Entities.Attach(entity);
    }
    #endregion

    #region Explicit Loading
    public virtual async Task LoadCollectionAsync<TProperty>(T entity,
        Expression<Func<T, IEnumerable<TProperty>>> collectionProperty,
        CancellationToken cancellationToken) where TProperty : class
    {
        Attach(entity);
        var collection = _dbContext.Entry(entity).Collection(collectionProperty);
        if (!collection.IsLoaded)
            await collection.LoadAsync(cancellationToken);
    }

    public virtual void LoadCollection<TProperty>(T entity, Expression<Func<T, IEnumerable<TProperty>>> collectionProperty)
        where TProperty : class
    {
        Attach(entity);
        var collection = _dbContext.Entry(entity).Collection(collectionProperty);
        if (!collection.IsLoaded)
            collection.Load();
    }

    public virtual async Task LoadReferenceAsync<TProperty>(T entity, Expression<Func<T, TProperty>> referenceProperty,
        CancellationToken cancellationToken) where TProperty : class
    {
        Attach(entity);
        var reference = _dbContext.Entry(entity).Reference(referenceProperty!);
        if (!reference.IsLoaded)
            await reference.LoadAsync(cancellationToken);
    }

    public virtual void LoadReference<TProperty>(T entity, Expression<Func<T, TProperty>> referenceProperty)
        where TProperty : class
    {
        Attach(entity);
        var reference = _dbContext.Entry(entity).Reference(referenceProperty!);
        if (!reference.IsLoaded)
            reference.Load();
    }
    #endregion


}