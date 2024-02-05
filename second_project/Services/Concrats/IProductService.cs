using Entities.Dtos;
using Entities.Models;

namespace Services.Concrats;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    Product? GetOneProduct(int id,bool trackChanges);
    void CreateProduct(ProductDtoForInsertion product);
    void UpdateProduct(ProductDtoForUpdate product);
    void DeleteProduct(int id);
    ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
}