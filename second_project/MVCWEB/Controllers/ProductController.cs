using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWEB.Models;

namespace MVCWEB.Controllers;

public class ProductController : Controller
{
    private readonly RepositoryContext _context;

    public ProductController(RepositoryContext context) // IConfiguration ekledim
    {
        _context = context;
    }

    
    // GET
    public IActionResult Index()
    {
        var model = _context.Products;

        return View(model);
    }

    
    public IActionResult Get(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id.Equals(id));

        return View(product);
    }
}