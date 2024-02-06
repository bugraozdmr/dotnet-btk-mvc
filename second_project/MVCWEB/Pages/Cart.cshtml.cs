using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Concrats;

namespace MVCWEB.Pages;

public class CartModel : PageModel
{
    private readonly IServiceManager _manager;
    public Cart Cart { get; set; }  // IoC

    public string returnUrl { get; set; } = "/";
    
    public CartModel(IServiceManager manager, Cart cart)
    {
        _manager = manager;
        Cart = cart;
    }
    

    // Kullanılan parametreler ve Modeldeki isimler aynı olmak zorunda !!!!! "Pages" 
    
    public void OnGet(string ReturnUrl)
    {
        // geldiği yere gitsin isteniyor -- boşsa ana sayfaya gider
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(int Id,string ReturnUrl)
    {
        Product? product = _manager
            .ProductService
            .GetOneProduct(Id, false);

        if (product is not null)
        {
            Cart.AddItem(product,1);
        }

        return Page();
    }

    
    // handler remove
    public IActionResult OnPostRemove(int Id, string ReturnUrl)
    {
        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id.Equals(Id)).Product);
        
        return Page();
    }
}