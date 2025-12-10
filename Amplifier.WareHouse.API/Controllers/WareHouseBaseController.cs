using Amplifier.WareHouse.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amplifier.WareHouse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WareHouseBaseController<TEntity, TDto>: ControllerBase, ICRUDController<TEntity, TDto> 
    where TEntity : class, new()
    where TDto : class, new()
{
    protected readonly IMapper _mapper;
    protected readonly IService<TEntity> _service;
    

    public WareHouseBaseController(IService<TEntity> service,  IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    public async virtual Task<IEnumerable<TDto>> Get()
    {
        var entities =  _service.Get();
        
        return _mapper.Map<IEnumerable<TDto>>(entities).ToList();
    }

    public virtual Task Update(TDto entityDto)
    {
        var entity = _mapper.Map<TEntity>(entityDto);
        
        return _service.Update(entity);
    }

    public virtual  Task Delete(int entityId)
    {
        return _service.Delete(entityId);
    }

    public virtual Task Add(TDto entityDto)
    {
        var entity = _mapper.Map<TEntity>(entityDto);

        return _service.Add(entity);
    }
}