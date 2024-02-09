using Entities.Models;

namespace Repositories.Extensions;

public static class ProductRepositoryExtension
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,
        int? CategoryID)
    {
        if (CategoryID is null)
            return products;
        else
            return products.Where(p => p.categoryId.Equals(CategoryID));
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
        string? SearchTerm)
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return products;
        else
            return products.Where(prd => prd.ProductName.ToLower()
                .Contains(SearchTerm.ToLower()));
        // içeriye koşul gerek where'de
    }

    public static IQueryable<Product> FilterByPrice(this IQueryable<Product> products,
        int? minPrice, int? maxPrice, bool IsValidPrice)
    {   // nullable olarak başlat yoksa hata alırsın yollarken
        if (IsValidPrice)
            return products.Where(prd => prd.Price >= minPrice && prd.Price <= maxPrice);

        return products;
    } 
    
    public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
        int pageNumber,int Pagesize)
    {
        return products
            .Skip((pageNumber - 1) * Pagesize)
            .Take(Pagesize);
    } 
}