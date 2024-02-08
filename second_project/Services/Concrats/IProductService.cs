using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Concrats;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(bool trackChanges);
    IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
    IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters);
    Product? GetOneProduct(int id,bool trackChanges);
    void CreateProduct(ProductDtoForInsertion product);
    void UpdateProduct(ProductDtoForUpdate product);
    void DeleteProduct(int id);
    ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
}