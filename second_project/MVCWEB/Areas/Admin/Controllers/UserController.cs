using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace MVCWEB.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IServiceManager _manager;

    public UserController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var users = _manager.AuthService.GetAllUsers();
        return View(users);
    }

    public IActionResult Create()
    {
        return View(new UserDtoForInsertion()
        {   // rolleri yollamak için gerekliydi
            Roles = new HashSet<string>(_manager
                .AuthService
                .Roles
                .Select(r => r.Name)
                .ToList())
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] UserDtoForInsertion userDto)
    {
        if (!ModelState.IsValid)
            return View(userDto);
        
        var result = await _manager.AuthService.CreateUser(userDto);

        if (result.result.Succeeded)
            return RedirectToAction("Index");

        foreach (var err in result.errors)
        {
            ModelState.AddModelError("",err);
        }

        return View(userDto);
    }

    public async Task<IActionResult> Update([FromRoute(Name = "id")]string id)
    {
        // id yazıyor ancak normalde bu username
        var user = await _manager.AuthService.GetOneUserForUpdate(id);
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
    {
        if (!ModelState.IsValid)
        {
            return View(userDto);
        }

        await _manager.AuthService.Update(userDto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
    {
        return View(new ResetPasswordDto()
        {
            Username = id
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        
        var result = await _manager.AuthService.ResetPassword(dto);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("","Something went wrong...Check your password.");
            return View(dto);
        }
        

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser([FromForm] UserDto userDto)
    {
        var result = await _manager.AuthService.DeleteUser(userDto.Username);

        return result.Succeeded
            ? RedirectToAction("Index")
            : View("Index");
    }
}