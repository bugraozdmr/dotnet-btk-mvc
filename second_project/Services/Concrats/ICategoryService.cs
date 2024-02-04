using Entities.Models;

namespace Services.Concrats;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories(bool trackChanges);
}