using Amplifier.WareHouse.Core;
using Amplifier.WareHouse.Core.DTO;
using Amplifier.WareHouse.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amplifier.WareHouse.API.Controllers;

public class SupplyController: WareHouseBaseController<Supply, SupplyDTO>
{
    public SupplyController(IService<Supply> service, IMapper mapper) : base(service, mapper)
    {
    }
    
    #region Inherited endpoints
   
    [HttpGet("GetSupplies")]
    public override async Task<IEnumerable<SupplyDTO>> Get()
    {
        var supplies = _service.Get().Where(s => !s.IsHidden);
        
        return _mapper.Map<IEnumerable<SupplyDTO>>(supplies);
    }

    // ProductDto
    [HttpPut("UpdateSupply")]
    public override Task Update(SupplyDTO supplyDto) => base.Update(supplyDto);

    [HttpDelete("DeleteSupply")]
    public override Task Delete(int supplyId) => base.Delete(supplyId);

    // ProductDto
    [HttpPost("AddSupply")]
    public override Task Add(SupplyDTO supplyDto) => base.Add(supplyDto); 
    
    #endregion

    [HttpPost("HideSuply")]
    public Task HideSupplyInPeriod(DateOnly startDate, DateOnly endDate)
    {
        //Невероятно криво
        ((SupplyService)_service).HideSuppliesInPeriod(startDate, endDate);
        return Task.CompletedTask;
    }
}