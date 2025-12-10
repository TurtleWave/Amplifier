using Amplifier.WareHouse.Core.DTO;
using Amplifier.WareHouse.Core.Interfaces;

namespace Amplifier.WareHouse.Core.Services;

public class ProductService: ServiceBase<Product>
{
    public ProductService(IRepository<Product> repository) : base(repository)
    {
    }

    public override Task Add(Product entity)
    {
        if  (!Repository.Get(item => item.Name == entity.Name).Any())
            return base.Add(entity);
        
        throw new Exception("Product name already exists");
    }
}