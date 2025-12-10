using Amplifier.WareHouse.Core;
using Amplifier.WareHouse.Core.DTO;
using Amplifier.WareHouse.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Amplifier.WareHouse.API.Controllers;


public class ProductController: WareHouseBaseController<Product, ProductDTO>
{
    
    public ProductController(IService<Product> service, IMapper mapper) : base(service, mapper)
    {
    }
    
    #region Inherited endpoints
    [HttpGet("GetProducts")]
    public override Task<IEnumerable<ProductDTO>> Get() => base.Get();

    // ProductDto
    [HttpPut("UpdateProduct")]
    public override Task Update(ProductDTO productDto) => base.Update(productDto);

    [HttpDelete("DeleteProduct")]
    public override Task Delete(int productId) => base.Delete(productId);

    // ProductDto
    [HttpPost("AddProduct")]
    public override Task Add(ProductDTO productDto) => base.Add(productDto); 
    
    #endregion
}