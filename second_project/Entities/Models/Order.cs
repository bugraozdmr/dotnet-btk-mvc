using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Order
{
    public int OrderId { get; set; }

    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
    
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Line is required")]
    public string? Line { get; set; }
    public string? Line { get; set; }
    public string? Line { get; set; }
    public string? City { get; set; }
    public bool GiftWrap { get; set; }
    public bool Shipped { get; set; }
    public DateTime OrderedAt { get; set; } = DateTime.Now;
}