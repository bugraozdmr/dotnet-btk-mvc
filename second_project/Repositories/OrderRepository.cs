using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(RepositoryContext context) : base(context)
    {
    }

    // son verilen siparişleri rahatça görmek için
    public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.Lines)
        .ThenInclude(cl => cl.Product)
        .OrderBy(o => o.Shipped)
        .ThenByDescending(o => o.OrderId);

    public Order? GetOrder(int id)
    {
        return FindByCondition(o => o.OrderId.Equals(id),false);
    }

    public void Complete(int id)
    {
        var order = FindByCondition(o => o.OrderId.Equals(id),true);
        
        if (order is null)
            throw new Exception("Order could not found");

        order.Shipped = true;
    }

    public void SaveOrder(Order order)
    {
        // birkaç tane gelen eklendi
        _context.AttachRange(order.Lines.Select(l => l.Product));
        if (order.OrderId == 0)
        {
            _context.Orders.Add(order);
        }
        
        _context.SaveChanges();
    }

    public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));
}