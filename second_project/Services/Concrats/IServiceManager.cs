namespace Services.Concrats;

public interface IServiceManager
{
    IProductService ProductService { get; }
    ICategoryService CategoryService { get; }
    IOrderService OrderService { get; }
    IAuthService AuthService { get; }
}