using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCWEB.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;

    public CartSummaryViewComponent(Cart cart)
    {
        _cart = cart;
    }

    // string olduğu için view'a gerek duyulmadı
    public string Invoke()
    {
        return _cart.Lines.Count.ToString();
    } 
}