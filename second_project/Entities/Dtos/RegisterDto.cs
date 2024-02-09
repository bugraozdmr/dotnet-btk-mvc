using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record RegisterDto
{
    [Required(ErrorMessage = "First name required")]
    public string? FirstName { get; init; }
    [Required(ErrorMessage = "Last name required")]
    public string? LastName { get; init; }

    [Required(ErrorMessage = "Username required")]
    public string? Username { get; init; }
    [Required(ErrorMessage = "Email required")]
    public string? Email { get; init; }
    [Required(ErrorMessage = "Password required")]
    public string? Password { get; init; }
}