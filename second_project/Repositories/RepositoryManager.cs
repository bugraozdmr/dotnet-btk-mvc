using Entities.Models;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public RepositoryManager(ICategoryRepository categoryRepository,IProductRepository productRepository, RepositoryContext context)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _context = context;
    }

    public IProductRepository Product => _productRepository;
    public ICategoryRepository Category => _categoryRepository;

    public void Save()
    {
        _context.SaveChanges();
    }
}