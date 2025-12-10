using Amplifier.WareHouse.Core.Interfaces;

namespace Amplifier.WareHouse.Core.Services;

public abstract class ServiceBase<T> : IService<T>
    where T : class
{
    protected IRepository<T> Repository;

    public ServiceBase(IRepository<T> repository)
    {
        Repository = repository;
    }

    public virtual T? Get(int id) =>
        Repository.Get(id);

    public virtual IEnumerable<T> Get() =>
        Repository.Get();

    public virtual IEnumerable<T> Get(Func<T, bool> predicate) =>
        Repository.Get(predicate);

    public virtual async Task Add(T entity) =>
        await Repository.Add(entity);

    public virtual async Task Delete(int id) =>
        await Repository.Delete(id);

    public virtual async Task Update(T entity) =>
        await Repository.Update(entity);
}