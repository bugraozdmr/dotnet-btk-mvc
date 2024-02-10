using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record UserDto
{ 
    // form elemanlarını biçimlendirdik
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Username required")]
    public string? Username { get; init; }
    
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "First Name required")]
    public string? FirstName { get; init; }
    
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Last Name required")]
    public string? LastName { get; init; }
    
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email required")]
    public string? Email { get; init; }
    
    //[Required(ErrorMessage = "phone number required")]
    //[MinLength(10,ErrorMessage = "phone number must be 10 digit")]
    //[MaxLength(10,ErrorMessage = "phone number must be 10 digit")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; init; }

    // roller tekrar edemeyecek
    public HashSet<string> Roles { get; set; } = new HashSet<string>();
}