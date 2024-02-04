using Entities.Models;

namespace Services.Concrats;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product? GetOneProduct(int id,bool trackChanges);
}