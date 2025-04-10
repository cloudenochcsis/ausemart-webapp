using ausemartweb.Models;

namespace ausemartweb.Services;

public class CartService
{
    private Dictionary<string, List<CartItem>> _carts = new();
    private readonly ProductService _productService;
    private int _nextId = 1;

    public CartService(ProductService productService)
    {
        _productService = productService;
    }

    public List<CartItem> GetCart(string sessionId)
    {
        if (!_carts.ContainsKey(sessionId))
        {
            _carts[sessionId] = new List<CartItem>();
        }
        return _carts[sessionId];
    }

    public void AddToCart(string sessionId, int productId, int quantity = 1)
    {
        var product = _productService.GetProductById(productId);
        if (product == null || product.StockQuantity < quantity)
        {
            return;
        }

        var cart = GetCart(sessionId);
        var existingItem = cart.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Add(new CartItem
            {
                Id = _nextId++,
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                ImageUrl = product.ImageUrl
            });
        }
    }

    public void UpdateCartItem(string sessionId, int cartItemId, int quantity)
    {
        var cart = GetCart(sessionId);
        var item = cart.FirstOrDefault(i => i.Id == cartItemId);

        if (item != null)
        {
            if (quantity <= 0)
            {
                cart.Remove(item);
            }
            else
            {
                var product = _productService.GetProductById(item.ProductId);
                if (product != null && product.StockQuantity >= quantity)
                {
                    item.Quantity = quantity;
                }
            }
        }
    }

    public void RemoveCartItem(string sessionId, int cartItemId)
    {
        var cart = GetCart(sessionId);
        var item = cart.FirstOrDefault(i => i.Id == cartItemId);

        if (item != null)
        {
            cart.Remove(item);
        }
    }

    public void ClearCart(string sessionId)
    {
        if (_carts.ContainsKey(sessionId))
        {
            _carts[sessionId].Clear();
        }
    }

    public decimal GetCartTotal(string sessionId)
    {
        return GetCart(sessionId).Sum(item => item.Total);
    }

    public int GetItemCount(string sessionId)
    {
        return GetCart(sessionId).Sum(item => item.Quantity);
    }

    public void Checkout(string sessionId)
    {
        var cart = GetCart(sessionId);
        
        // In a real system, you'd process payment and create an order here
        
        // Update inventory
        foreach (var item in cart)
        {
            var product = _productService.GetProductById(item.ProductId);
            if (product != null)
            {
                product.StockQuantity -= item.Quantity;
                _productService.UpdateProduct(product);
            }
        }
        
        // Clear the cart
        ClearCart(sessionId);
    }
}