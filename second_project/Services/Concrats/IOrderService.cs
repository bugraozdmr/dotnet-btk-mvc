using Entities.Models;

namespace Services.Concrats;

public interface IOrderService
{
    IQueryable<Order> Orders { get; }
    Order? GetOrder(int id);
    void Complete(int id);
    void SaveOrder(Order order);
    int NumberOfInProcess { get; }
}