using System.ComponentModel.DataAnnotations;

namespace Amplifier.WareHouse.Core;

public class Cost
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateOnly Date { get; set; }
   
    public int Quantity { get; set; }
    public bool IsHidden { get; set; } = false;
    
    public Product Product { get; set; }
}