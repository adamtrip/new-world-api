using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Application.Common.Persistence;
using Domain.Common.Contracts;
using Infrastructure.Persistence.Context;
using Mapster;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Persistence.Repository;

// Inherited from Ardalis.Specification's RepositoryBase<T>
public class ApplicationDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    private readonly ApplicationDbContext db;
    public ApplicationDbRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        db = dbContext;
    }

    public IEnumerable<TResult> Select<TResult>(Func<T, TResult> selector)
    {
        return db.Set<T>().Select(selector);
    }

    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    // This is only done when no Selector is defined, so regular specifications with a selector also still work.
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
}

//public class ApplicationDbRepository<T> : IRepository<T> where T : class
//{
//    private readonly ApplicationDbContext _context;
//    public ApplicationDbRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public void Add(T entity)
//    {
//        _context.Set<T>().Add(entity);
//    }

//    public async Task AddAsync(T entity)
//    {
//        await _context.Set<T>().AddAsync(entity);
//    }

//    public void AddRange(IEnumerable<T> entities)
//    {
//        _context.Set<T>().AddRange(entities);
//    }

//    public async Task AddRangeAsync(IEnumerable<T> entities)
//    {
//        await _context.AddRangeAsync(entities);
//    }

//    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
//    {
//        return _context.Set<T>().Where(expression);
//    }

//    public IEnumerable<T> GetAll()
//    {
//        return _context.Set<T>().ToList();
//    }

//    public T GetById(int id)
//    {
//        return _context.Set<T>().Find(id);
//    }

//    public async Task<T> GetByIdAsync(int id)
//    {
//        return await _context.Set<T>().FindAsync(id);
//    }

//    public void Remove(T entity)
//    {
//        _context.Set<T>().Remove(entity);
//    }


//    public void RemoveRange(IEnumerable<T> entities)
//    {
//        _context.Set<T>().RemoveRange(entities);
//    }
//}