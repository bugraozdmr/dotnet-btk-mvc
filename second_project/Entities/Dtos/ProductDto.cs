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

    public string? Summary { get; init; } = String.Empty;
    
    // önce dosya yüklenmeli -- ondan set kaldı -- init olursa sonradan değişemez -- model stateden geçmesi içinde nullable olmalı
    public string? ImageUrl { get; set; }
    
    public int? categoryId { get; init; }        // foreign key
}