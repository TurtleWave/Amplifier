using Amplifier.WareHouse.Core;
using Microsoft.EntityFrameworkCore;

namespace Amplifier.WareHouse.DAL.Repositories;

public class ProductRepository: EntityRepository<Product>
{
    public ProductRepository(DbContext context) : base(context)
    {
    }

    public override IEnumerable<Product> Get()
    {
        var product = DbSet
            .Include(p => p.Supplies)
            .Include(p => p.Costs);
        
        return product;
    }

    public override Product? Get(int id)
    {
        var product =  DbSet
            .Include(p => p.Supplies)
            .Include(p => p.Costs).FirstOrDefault(p => p.Id == id);
        
        return product;
    }
}