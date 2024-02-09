using System.ComponentModel.DataAnnotations;

namespace MVCWEB.Models;

public class LoginModel
{
    private string? _returnurl;
    

    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    public string? ReturnUrl
    {
        get
        {
            if (_returnurl is null)
                return "/";
            else
                return _returnurl;
        }
        set
        {
            _returnurl = value;
        }
    }
}