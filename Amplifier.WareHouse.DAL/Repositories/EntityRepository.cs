using Amplifier.WareHouse.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amplifier.WareHouse.DAL.Repositories;

public abstract class EntityRepository<T> : IRepository<T>
    where T : class
{
    private DbContext _context;
    protected DbSet<T> DbSet;

    public EntityRepository(DbContext context)
    {
        _context = context;
        DbSet = context.Set<T>();
    }

    public virtual T? Get(int id) =>
        DbSet.Find(id);

    public virtual IEnumerable<T> Get() =>
        DbSet;

    public virtual IEnumerable<T> Get(Func<T, bool> predicate) =>
        Get().Where(predicate);

    public virtual async Task Add(T entity)
    {
        await DbSet.AddAsync(entity);

        await Save();
    }

    public virtual async Task Delete(int id)
    {
        T? entity = await DbSet.FindAsync(id);

        if (entity == null)
            //throw new
            return;

        DbSet.Remove(entity);
        await Save();
    }

    public virtual async Task Update(T entity)
    {
        DbSet.Update(entity);

        await Save();
    }

    public async Task Save() =>
        await _context.SaveChangesAsync();
}