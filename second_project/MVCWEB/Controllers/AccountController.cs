using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWEB.Models;

namespace MVCWEB.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl="/")
    {
        // aşşağı tarafa yolluyor return url değerini
        return View(new LoginModel()
        {
            ReturnUrl = returnUrl
        });
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromForm]LoginModel model)
    {
        if (ModelState.IsValid)
        {
            User user = await _userManager.FindByNameAsync(model.Username);
            
            if (user is not null)
            {
                // oturum açma
                await _signInManager.SignOutAsync();
                if ((await _signInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                {
                    return Redirect(model?.ReturnUrl ?? "/");
                }
            }
            ModelState.AddModelError("Error","User not found.");
        }
        
        return View(model);
    }

    public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string returnUrl="/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(returnUrl);
    }

    public IActionResult Register()
    {
        return View();
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterDto model)
    {
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager
                    .AddToRoleAsync(user, "User");

                if (roleResult.Succeeded)   // boş gitmesin
                    return RedirectToAction("Login", new {ReturnUrl = "/"});
                
                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
        }
        
        return View(model);
    }

    public IActionResult AccessDenied([FromRoute] string returnUrl)
    {
        return View(returnUrl);
    }
}