using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace MVCWEB.Controllers;

public class OrderController : Controller
{
    private readonly IServiceManager _manager;
    private readonly Cart _cart;
    
    public OrderController(IServiceManager manager, Cart cart)
    {
        _manager = manager;
        _cart = cart;
    }

    // burası IActionResult'da olurdu -- artık viewler hata almasın diye böyle başta oluştur gönder
    [Authorize] //login olması yeter
    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout([FromForm]Order order)
    {
        if (_cart.Lines.Count() == 0)
        {
            ModelState.AddModelError("","Sorry, your cart is empty.");
        }

        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines.ToArray();
            //Console.WriteLine(order.);
            _manager.OrderService.SaveOrder(order);
            _cart.Clear();

            return RedirectToPage("/Complete", new {OrderId = order.OrderId});
        }

        return View(order);
    }
}