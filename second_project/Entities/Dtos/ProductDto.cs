using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos;

public record ProductDto
{
    public int Id { get; init; }
    [Required(ErrorMessage = "Product Name required")]
    public string? ProductName { get; init; }
    [Required(ErrorMessage = "Price required")]
    public decimal Price { get; init; }

    public int? categoryId { get; init; }        // foreign key
}