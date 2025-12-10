using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Amplifier.WareHouse.Core;

public class Product
{
    public int Id { get; set; }
    
    [StringLength( maximumLength: 100, MinimumLength = 5, ErrorMessage = "Incorrect product name (minimum size 5, maximum 100)")] 
    public string Name { get; set; }
    public string Description { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 1.")]
    public double Price { get; set; }
    
    [NotMapped]
    public int Count {
        get
        {
            var suppliesCount = Supplies.Where(x => x.ProductId == Id)?.Sum(x => x.Quantity) ?? 0;   
            var costsCount =  Costs.Where(x => x.ProductId == Id)?.Sum(x => x.Quantity) ?? 0;
            
            return suppliesCount - costsCount;
        } 
    }
    
    public IEnumerable<Cost> Costs { get; set; } = new List<Cost>();
    public IEnumerable<Supply> Supplies { get; set; } = new List<Supply>();
}