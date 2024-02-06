using Entities.Models;
using Repositories.Contracts;
using Services.Concrats;

namespace Services;

public class OrderManager : IOrderService
{
    private readonly IRepositoryManager _manager;

    public OrderManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IQueryable<Order> Orders => _manager.Order.Orders;
    public Order? GetOrder(int id)
    {
        return _manager.Order.GetOrder(id);
    }

    public void Complete(int id)
    {
        _manager.Order.Complete(id);
        _manager.Save();
    }

    public void SaveOrder(Order order)
    {
        _manager.Order.SaveOrder(order);
        _manager.Save();
    }

    public int NumberOfInProcess => _manager.Order.NumberOfInProcess;
}