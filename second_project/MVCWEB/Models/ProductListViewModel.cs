using Entities.Dtos;
using Entities.Models;

namespace MVCWEB.Models;

public class ProductListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    public Pagination Pagination { get; set; } = new();
    public int TotalCount => Products.Count();
}