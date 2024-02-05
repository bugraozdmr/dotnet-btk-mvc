using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Product Name required")]
    public string? ProductName { get; set; }
    [Required(ErrorMessage = "Price required")]
    public decimal Price { get; set; }

    public int? categoryId { get; set; }        // foreign key
    public Category? Category { get; set; }     // navigation property
}