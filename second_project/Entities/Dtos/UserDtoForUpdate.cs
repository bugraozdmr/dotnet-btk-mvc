namespace Entities.Dtos;

public record UserDtoForUpdate : UserDto
{
    // referans tipi ifade başlatılmalıdır
    public HashSet<string> UserRoles
    {
        get;
        set;
    } = new HashSet<string>();
}