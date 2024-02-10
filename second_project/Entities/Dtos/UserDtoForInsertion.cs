
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record UserDtoForInsertion : UserDto
{
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password required")]
    public string? Password { get; init; }
}