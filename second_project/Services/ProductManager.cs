using Entities.Models;
using Repositories.Contracts;
using Services.Concrats;

namespace Services;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _manager;

    public ProductManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _manager.Product.GetAllProducts(trackChanges);
    }

    public Product? GetOneProduct(int id, bool trackChanges)
    {
        var product = _manager.Product.GetOneProduct(id, trackChanges);

        if (product is null)
        {
            throw new Exception("Product not found !");
        }

        return product;
    }

    public void CreateProduct(Product product)
    {
        _manager.Product.CreateProduct(product);
        _manager.Save();
    }

    public void UpdateProduct(Product product)
    {
        var entity = _manager.Product.GetOneProduct(product.Id, true);
        entity.ProductName = product.ProductName;
        entity.Price = product.Price;
        
        _manager.Save();
    }

    public void DeleteProduct(int id)
    {
        var product = GetOneProduct(id, false);

        if (product is not null)
        {
            _manager.Product.deleteProduct(product);
            _manager.Save();
        }
    }
}