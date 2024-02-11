using Microsoft.AspNetCore.Mvc;
using Services.Concrats;

namespace MVCWEB.Components;

public class OrdersInProgressViewComponent : ViewComponent
{
    private readonly IServiceManager _manager;

    public OrdersInProgressViewComponent(IServiceManager manager)
    {
        _manager = manager;
    }

    public string Invoke()
    {
        return _manager.OrderService.NumberOfInProcess.ToString();
    }
}