using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using MVCWEB.Models;
using Repositories;
using Repositories.Contracts;
using Services.Concrats;

namespace MVCWEB.Controllers;

//mysql başlamazsa portu değiştir bir arttır yeter
// sonra my.cnf'e git ordan portu hep değiştir
// port bilgisi artık girmen gerek port=3307 diye

public class ProductController : Controller
{
    private readonly IServiceManager _manager;
    
    public ProductController(IServiceManager manager) // IConfiguration ekledim
    {
        _manager = manager;
    }

    
    public IActionResult Index(ProductRequestParameters p)
    {
        // p değerini otomatik tanıdı productreqparameters'da geçiyor diyo -- bizde routing olarak verdik CategoryId diye zaten
        var products = _manager.ProductService.GetAllProductsWithDetails(p);
        var pagination = new Pagination()
        {
            CurrentPage = p.PageNumber,
            ItemsPerPage = p.Pagesize,
            TotalItems = _manager.ProductService.GetAllProducts(false).Count()
        };

        return View(new ProductListViewModel()
        {
            Products = products,
            Pagination = pagination
        });
    }

    
    public IActionResult Get([FromRoute(Name = "id")]int id)
    {
        var product = _manager.ProductService
            .GetOneProduct(id, false);
            

        return View(product);
    }
}