using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts;

public interface IProductRepository : IRepositoryBase<Product>
{
    IQueryable<Product> GetAllProducts(bool trackChanges);
    IQueryable<Product> GetShowcaseProducts(bool trackChanges);
    IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters);
    Product? GetOneProduct(int id,bool trackChanges);
    void CreateProduct(Product product);

    void deleteProduct(Product product);
    void UpdateProduct(Product product);
}