using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Concrats;

public interface IAuthService
{
    IEnumerable<IdentityRole> Roles { get; }
    
    
    IEnumerable<User> GetAllUsers();
    // admin özel kullanıcı üretmek istiyorsa ...
    Task<(IdentityResult result,List<string> errors)> CreateUser(UserDtoForInsertion userDto);
    // roller ile beraber user'i almak için
    Task<UserDtoForUpdate> GetOneUserForUpdate(string username);
    Task<User> GetOneUser(string userName);
    Task Update(UserDtoForUpdate userDto);
    Task<IdentityResult> ResetPassword(ResetPasswordDto model);
    Task<IdentityResult> DeleteUser(string userName);
}