using System.ComponentModel.DataAnnotations;

namespace Amplifier.WareHouse.Core.DTO;

public class CostDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public DateOnly Date { get; set; }
   
    [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than or equal to 1.")]
    public int Quantity { get; set; }
}