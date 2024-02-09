using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories;

// daha kalıtılamaz bu -- eklenti metodlar ile büyür
public sealed class ProductRepository : RepositoryBase<Product> , IProductRepository
{
    public ProductRepository(RepositoryContext context) : base(context)
    {
    }

    public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
    public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
    {
        return FindAll(trackChanges)
            .Where(p => p.Showcase.Equals(true));
    }

    public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
    {
        // category'dekiler düşecek buraya 

        // extension halleder
        return _context
            .Products
            .FilteredByCategoryId(parameters.CategoryId)
            .FilteredBySearchTerm(parameters.SearchTerm)
            .FilterByPrice(parameters.MinPrice, parameters.MaxPrice, parameters.IsValidPrice)
            .ToPaginate(parameters.PageNumber, parameters.Pagesize);
    }

    public Product GetOneProduct(int id, bool trackChanges) => FindByCondition(
        p => p.Id.Equals(id)
        , trackChanges);

    public void CreateProduct(Product product) => Create(product);
    public void deleteProduct(Product product) => Remove(product);
    public void UpdateProduct(Product product) => Update(product);
}