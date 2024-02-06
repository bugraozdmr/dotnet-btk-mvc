using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCWEB.Infrastructe.Extensions;
using Services.Concrats;

namespace MVCWEB.Pages;

public class CartModel : PageModel
{
    private readonly IServiceManager _manager;
    public Cart Cart { get; set; }  // IoC

    public string ReturnUrl { get; set; } = "/";
    
    public CartModel(IServiceManager manager, Cart cart)
    {
        _manager = manager;
        Cart = cart;
    }
    

    // Kullanılan parametreler ve Modeldeki isimler aynı olmak zorunda !!!!! "Pages" 
    // prop için demiyorum prop farklı isimde olabilir ... kullanılan localler aynı olacak ama
    
    public void OnGet(string returnUrl)
    {
        // geldiği yere gitsin isteniyor -- boşsa ana sayfaya gider
        ReturnUrl = returnUrl ?? "/";
        //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
    }

    public IActionResult OnPost(int Id,string returnUrl)
    {
        Product? product = _manager
            .ProductService
            .GetOneProduct(Id, false);

        if (product is not null)
        {
            // posttan önce yine kontrol etsin
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); -- artık session cart çalışıyor
            // artık session carta gidiyor
            Cart.AddItem(product,1);
            // HttpContext.Session.SetJson<Cart>("cart",Cart);
        }

        return RedirectToPage(new { returnUrl = returnUrl});
    }

    
    // handler remove
    public IActionResult OnPostRemove(int Id, string returnUrl)
    {
        // işlem sonrası session'a sürekli tekrar yazılır
        
        //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id.Equals(Id)).Product);
        //HttpContext.Session.SetJson<Cart>("cart",Cart);
        return Page();
    }
}