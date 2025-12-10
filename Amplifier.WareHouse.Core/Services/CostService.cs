using Amplifier.WareHouse.Core.Interfaces;

namespace Amplifier.WareHouse.Core.Services;

public class CostService: ServiceBase<Cost>
{
    public CostService(IRepository<Cost> repository) : base(repository)
    {
    }

    public override Cost? Get(int id)
    {
        return base.Get(id);
    }

    public Task HideCostsInPeriod(DateOnly periodStart, DateOnly periodEnd)
    {
        var targetCosts = Repository.Get(c => c.Date >= periodStart && c.Date <= periodEnd);
        
        foreach (var cost in targetCosts)
        {
            cost.IsHidden = true;
            Repository.Update(cost);
        }
        
        Repository.Save();
        return Task.CompletedTask;
    }
}