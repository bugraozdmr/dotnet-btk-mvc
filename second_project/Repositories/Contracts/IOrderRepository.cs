using Entities.Models;

namespace Repositories.Contracts;

public interface IOrderRepository
{
    IQueryable<Order> Orders { get; }
    Order? GetOrder(int id);
    void Complete(int id);
    void SaveOrder(Order order);
    int NumberOfInProcess { get; }
}