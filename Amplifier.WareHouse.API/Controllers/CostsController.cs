using Amplifier.WareHouse.Core;
using Amplifier.WareHouse.Core.DTO;
using Amplifier.WareHouse.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amplifier.WareHouse.API.Controllers;

public class CostsController: WareHouseBaseController<Cost, CostDTO>
{
    public CostsController(IService<Cost> service, IMapper mapper) : base(service, mapper)
    {
    }
    
    #region Inherited endpoints

    [HttpGet("GetProductsCosts")]
    public override async Task<IEnumerable<CostDTO>> Get()
    {
        var supplies = _service.Get().Where(s => !s.IsHidden);
        
        return _mapper.Map<IEnumerable<CostDTO>>(supplies);
    }

    // ProductDto
    [HttpPut("UpdateProductCost")]
    public override Task Update(CostDTO costDto) => base.Update(costDto);

    [HttpDelete("DeleteProductCost")]
    public override Task Delete(int costId) => base.Delete(costId);

    // ProductDto
    [HttpPost("AddProductCost")]
    public override Task Add(CostDTO costDto) => base.Add(costDto); 
    
    #endregion

    [HttpGet("GetProductCosts")]
    public async Task<IEnumerable<CostDTO>> GetProductCostsById(int productId)
    {
        var costs = _service.Get(c => c.ProductId == productId)
            .Where(c => !c.IsHidden);
        
        return _mapper.Map<IEnumerable<CostDTO>>(costs);
    }
    
    [HttpPost("HideCosts")]
    public Task HideСostsInPeriod(DateOnly startDate, DateOnly endDate)
    {
        //Невероятно криво
        ((CostService)_service).HideCostsInPeriod(startDate, endDate);
        return Task.CompletedTask;
    }
}