using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Concrats;

namespace Services;

public class AuthManager : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    

    public AuthManager(RoleManager<IdentityRole> roleManager
        , UserManager<User> userManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
    public IEnumerable<User> GetAllUsers()
    {
        return _userManager.Users.ToList();
    }

    public async Task<(IdentityResult result, List<string>? errors)> CreateUser(UserDtoForInsertion userDto)
    {
        // bu metod hocanınki ile değişebilir hata fırlatmasın diye yazıldı...
        
        var user = _mapper.Map<User>(userDto);
        
        var result = await _userManager.CreateAsync(user, userDto.Password);

        List<string> errors = new List<string>();

        
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                errors.Add(error.Description);
            }

            return (result,errors);
        }

        if (userDto.Roles.Count > 0)
        {
            var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);

            if (!roleResult.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }

                return (result,errors);
            }
            
            //hata fırlamasın biz alalım onları sayfaya taşıyalım
            //throw new Exception("System have problems with roles");
        }

        return (result,errors);
    }

    public async Task<UserDtoForUpdate> GetOneUserForUpdate(string username)
    {
        var user = await GetOneUser(username);

        var userDto = _mapper.Map<UserDtoForUpdate>(user);
        // tüm rolleri aldı önce
        userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
        // userdto userroles olarak sadece userın sahip olduklarını aldı
        userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

        return userDto;
    }

    public async Task<User> GetOneUser(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);

        if (user is not null)
            return user;
        
        throw new Exception("User could not found.");
    }

    public async Task Update(UserDtoForUpdate userDto)
    {
        var user = await GetOneUser(userDto.Username);

        user.PhoneNumber = userDto.PhoneNumber;
        user.Email = userDto.Email;

        var result = await _userManager.UpdateAsync(user);
            
        if (userDto.Roles.Count > 0)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            // kullanıcının tüm rolleri gitti
            var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles);
            var r2 = await _userManager.AddToRolesAsync(user, userDto.Roles);
        }
            
        return;
    }

    public async Task<IdentityResult> ResetPassword(ResetPasswordDto model)
    {
        var user = await GetOneUser(model.Username);

        // önce siler sonra ekler
        await _userManager.RemovePasswordAsync(user);

        var result = await _userManager.AddPasswordAsync(user, model.Password);
        return result;
    }

    public async Task<IdentityResult> DeleteUser(string userName)
    {
        var user = await GetOneUser(userName);
        return await _userManager.DeleteAsync(user);
    }
}