using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record ResetPasswordDto
{
    public string? Username { get; init; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password",ErrorMessage = "Passwords doesn't match.")]
    public string? ConfirmPassword { get; init; }
}