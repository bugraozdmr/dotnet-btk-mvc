using Entities.Models;
using Repositories.Contracts;

namespace Repositories;

public class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

    public Product GetOneProduct(int id, bool trackChanges) => FindByCondition(
        p => p.Id.Equals(id)
        , trackChanges);

    public void CreateProduct(Product product) => Create(product);
    public void deleteProduct(Product product) => Remove(product);
}