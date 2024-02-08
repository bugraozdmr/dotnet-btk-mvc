using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Concrats;

namespace Services;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;
    
    public ProductManager(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        var products = _manager.Product.GetAllProducts(trackChanges);
        return products;
    }

    public IEnumerable<Product> getLatestProducts(int? n, bool trackChanges)
    {
        int number = n ?? 5;
        return _manager.Product.FindAll(false)
            .OrderByDescending(prd => prd.Id)
            .Take(number);
    }

    public IEnumerable<Product> GetShowcaseProducts(bool trackChanges)
    {
        return _manager.Product.GetShowcaseProducts(trackChanges);
    }

    public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
    {
        return _manager.Product.GetAllProductsWithDetails(parameters);
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

    public void CreateProduct(ProductDtoForInsertion product)
    {
        var productToGo = _mapper.Map<Product>(product); 
        
        _manager.Product.CreateProduct(productToGo);
        _manager.Save();
    }

    public void UpdateProduct(ProductDtoForUpdate product)
    {
        // var entity = _manager.Product.GetOneProduct(product.Id, true);
        
        // entity.ProductName = product.ProductName;
        // entity.Price = product.Price;
        // entity.categoryId = product.categoryId;

        var entity = _mapper.Map<Product>(product);
        _manager.Product.UpdateProduct(entity);
        
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

    public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
    {
        var product = GetOneProduct(id, trackChanges);
        var productDto = _mapper.Map<ProductDtoForUpdate>(product);
        return productDto;
    }
}