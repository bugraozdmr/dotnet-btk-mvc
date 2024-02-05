using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    
    
    public decimal Price { get; set; }

    public int? categoryId { get; set; }        // foreign key
    public Category? Category { get; set; }     // navigation property
}