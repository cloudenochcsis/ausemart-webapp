using Microsoft.AspNetCore.Mvc;
using AusemartApi.Models;
using AusemartApi.Services;

namespace AusemartApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(OrderService orderService, ILogger<OrdersController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    // GET: api/orders
    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        try
        {
            return Ok(_orderService.GetOrders());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting orders");
            return StatusCode(500, "An error occurred while retrieving orders");
        }
    }

    // GET: api/orders/5
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrder(int id)
    {
        try
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting order with ID {OrderId}", id);
            return StatusCode(500, "An error occurred while retrieving the order");
        }
    }

    // POST: api/orders
    [HttpPost]
    public ActionResult<Order> CreateOrder(Order order)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var newOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating order");
            return StatusCode(500, "An error occurred while creating the order");
        }
    }

    // PATCH: api/orders/5/status
    [HttpPatch("{id}/status")]
    public IActionResult UpdateOrderStatus(int id, [FromBody] string status)
    {
        try
        {
            var order = _orderService.UpdateOrderStatus(id, status);
            if (order == null)
            {
                return NotFound();
            }
            
            return Ok(order);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating status for order with ID {OrderId}", id);
            return StatusCode(500, "An error occurred while updating the order status");
        }
    }
}