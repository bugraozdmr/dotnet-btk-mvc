namespace Entities.Models;

public class CartLine
{
    public int CartlineId { get; set; }
    // tanımlanan yerde direkt referans alsın
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}