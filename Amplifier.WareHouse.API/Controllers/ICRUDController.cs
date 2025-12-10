namespace Amplifier.WareHouse.API.Controllers;

public interface ICRUDController<TEntity, TDto> 
    where TEntity: class, new()
    where TDto: class, new()
{
    public Task<IEnumerable<TDto>> Get();
    
    public Task Update(TDto entity);

    public Task Delete(int entityId);

    public Task Add(TDto entity);
}