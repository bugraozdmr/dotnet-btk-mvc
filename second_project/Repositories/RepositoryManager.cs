using Entities.Models;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IOrderRepository _orderRepository;

    // bunlar kesinlikle constructorda geçilmeliler
    public RepositoryManager(ICategoryRepository categoryRepository
        ,IProductRepository productRepository
        , RepositoryContext context, IOrderRepository orderRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _context = context;
        _orderRepository = orderRepository;
    }

    public IProductRepository Product => _productRepository;
    public ICategoryRepository Category => _categoryRepository;
    public IOrderRepository Order => _orderRepository;

    public void Save()
    {
        _context.SaveChanges();
    }
}