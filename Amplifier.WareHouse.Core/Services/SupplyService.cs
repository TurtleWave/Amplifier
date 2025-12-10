using Amplifier.WareHouse.Core.Interfaces;

namespace Amplifier.WareHouse.Core.Services;

public class SupplyService: ServiceBase<Supply>
{
    public SupplyService(IRepository<Supply> repository) : base(repository)
    {
    }
    
    public Task HideSuppliesInPeriod(DateOnly periodStart, DateOnly periodEnd)
    {
        var targetSupplies = Repository.Get(c => c.Date >= periodStart && c.Date <= periodEnd);
        
        foreach (var supply in targetSupplies)
        {
            supply.IsHidden = true;
            Repository.Update(supply);
        }
        
        Repository.Save();
        return Task.CompletedTask;
    }
}