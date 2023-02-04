namespace Application.Common.Persistence;

// The Repository for the Application Db
// I(Read)RepositoryBase<T> is from Ardalis.Specification

/// <summary>
/// The regular read/write repository for an aggregate root.
/// </summary>
public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
    public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector);
}

/// <summary>
/// The read-only repository for an aggregate root.
/// </summary>
public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot
{
    IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector);
}

/// <summary>
/// A special (read/write) repository for an aggregate root,
/// that also adds EntityCreated, EntityUpdated or EntityDeleted
/// events to the DomainEvents of the entities before adding,
/// updating or deleting them.
/// </summary>

public interface IRepositoryWithEvents<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

//public interface IRepository<T> where T : class
//{
//    T GetById(int id);
//    Task<T> GetByIdAsync(int id);
//    IEnumerable<T> GetAll();
//    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
//    void Add(T entity);
//    Task AddAsync(T entity);
//    void AddRange(IEnumerable<T> entities);
//    Task AddRangeAsync(IEnumerable<T> entities);
//    void Remove(T entity);
//    void RemoveRange(IEnumerable<T> entities);
//}