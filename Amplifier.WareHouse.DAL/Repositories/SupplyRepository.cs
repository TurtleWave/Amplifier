using Amplifier.WareHouse.Core;
using Microsoft.EntityFrameworkCore;

namespace Amplifier.WareHouse.DAL.Repositories;

public class SupplyRepository: EntityRepository<Supply>
{
    public SupplyRepository(DbContext context) : base(context)
    {
    }
}