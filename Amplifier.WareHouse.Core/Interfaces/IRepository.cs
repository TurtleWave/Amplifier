namespace Amplifier.WareHouse.Core.Interfaces;

public interface IRepository<TEntity>
    where TEntity : class
{
    public TEntity? Get(int id);
    public IEnumerable<TEntity> Get();
    public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    public Task Add(TEntity entity);
    public Task Delete(int id);
    public Task Update(TEntity entity);

    public Task Save();
}