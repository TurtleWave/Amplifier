using Amplifier.WareHouse.Core;
using Microsoft.EntityFrameworkCore;

namespace Amplifier.WareHouse.DAL.Repositories;

public class CostRepository: EntityRepository<Cost>
{
    public CostRepository(DbContext context) : base(context)
    {
    }
}