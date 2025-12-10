using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Amplifier.WareHouse.Core.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    
    [StringLength( maximumLength: 100, MinimumLength = 5, ErrorMessage = "Incorrect product name (minimum size 5, maximum 100)")] 
    public string Name { get; set; }
    public string Description { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 1.")]
    public double Price { get; set; }
    
    [ReadOnly(true)]
    public int Count { get; set; } 
}