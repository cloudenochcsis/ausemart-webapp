using AusemartApi.Models;

namespace AusemartApi.Services;

public class OrderService
{
    private List<Order> _orders = new();
    private int _nextOrderId = 1;
    private int _nextOrderItemId = 1;
    private readonly ProductService _productService;

    public OrderService(ProductService productService)
    {
        _productService = productService;
    }

    public IEnumerable<Order> GetOrders()
    {
        return _orders;
    }

    public Order? GetOrderById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public Order CreateOrder(Order order)
    {
        // Set the order ID and item IDs
        order.Id = _nextOrderId++;
        order.OrderDate = DateTime.Now;
        
        // Calculate total and set order item IDs
        decimal total = 0;
        foreach (var item in order.Items)
        {
            item.Id = _nextOrderItemId++;
            
            // Get the product to update stock
            var product = _productService.GetProductById(item.ProductId);
            if (product != null)
            {
                // Update stock
                product.StockQuantity -= item.Quantity;
                _productService.UpdateProduct(product.Id, product);
                
                // Calculate total
                total += item.Total;
            }
        }
        
        order.TotalAmount = total;
        _orders.Add(order);
        
        return order;
    }

    public Order? UpdateOrderStatus(int id, string status)
    {
        var order = _orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
        {
            return null;
        }

        order.Status = status;
        return order;
    }
}