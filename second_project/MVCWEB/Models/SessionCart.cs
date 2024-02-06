using System.Text.Json.Serialization;
using Entities.Models;
using MVCWEB.Infrastructe.Extensions;

namespace MVCWEB.Models;

// Bu şekilde veritabanı yorulmuyor ve session çalışıyor

public class SessionCart : Cart
{
    // serileştirilmiş olan ifade tekrar serileştirilmesin
    [JsonIgnore]
    // bu özellik gelenlerde kullanılacak
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;

        SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();

        cart.Session = session;
        return cart;
    }
    
    public override void AddItem(Product product, int quantity)
    {
        // cart.cs'e artık gerek kalmayacak
        base.AddItem(product, quantity);
        Session?.SetJson<SessionCart>("cart",this);
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson<SessionCart>("cart",this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }
}