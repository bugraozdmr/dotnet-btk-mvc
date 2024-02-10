using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Concrats;

namespace MVCWEB.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var model = _manager.ProductService.GetAllProducts(false);
        return View(model);
    }

    public IActionResult Create()
    {
        // select list
        ViewBag.Categories = getCategoriesSelectList();
        return View();
    }

    private SelectList getCategoriesSelectList()
    {
        return new SelectList(_manager.CategoryService.GetAllCategories(false)
            , "CategoryId", "CategoryName", "1");
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm]ProductDtoForInsertion productDto , IFormFile file)
    {
        if (file is not null)
        {
            // file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
        
            // garbage collector hemen çalışsın bitsin
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
        
        
        if (ModelState.IsValid)
        {
            productDto.ImageUrl = String.Concat("/images/", file.FileName);
            
            _manager.ProductService.CreateProduct(productDto);
        
            return RedirectToAction("Index");    
        }
        
        
        return View(productDto);
    }

    public IActionResult Update([FromRoute(Name = "id")]int id)
    {
        ViewBag.Categories = getCategoriesSelectList();
        
        var model = _manager.ProductService.GetOneProductForUpdate(id, false);
        
        return View(model);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update([FromForm]ProductDtoForUpdate productDto,IFormFile file)
    {
        if (ModelState.IsValid)
        {
            // file operation
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
        
            // garbage collector hemen çalışsın bitsin
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            productDto.ImageUrl = String.Concat("/images/", file.FileName);    
            
            _manager.ProductService.UpdateProduct(productDto);
        
            return RedirectToAction("Index","Product");    
        }

        return View(productDto);
    }

    [HttpGet]
    public IActionResult Delete([FromRoute(Name = "id")]int id)
    {
        _manager.ProductService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
    
}