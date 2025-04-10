using ausemartweb.Models;

namespace ausemartweb.Services;

public class CartService : ICartService
{
    private readonly Dictionary<string, Cart> _carts = new();
    private readonly IProductService _productService;

    public CartService(IProductService productService)
    {
        _productService = productService;
    }

    public Cart GetCart(string cartId)
    {
        if (!_carts.ContainsKey(cartId))
        {
            _carts[cartId] = new Cart { Id = cartId };
        }
        return _carts[cartId];
    }

    public void AddToCart(string cartId, int productId, int quantity = 1)
    {
        var cart = GetCart(cartId);
        var product = _productService.GetProductById(productId);
        
        if (product == null)
            return;

        var existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);
        
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                Id = cart.Items.Count > 0 ? cart.Items.Max(i => i.Id) + 1 : 1,
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                ImageUrl = product.ImageUrl,
                Attributes = product.Attributes
            });
        }

        cart.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCartItem(string cartId, int productId, int quantity)
    {
        var cart = GetCart(cartId);
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        
        if (item != null)
        {
            if (quantity > 0)
            {
                item.Quantity = quantity;
            }
            else
            {
                RemoveFromCart(cartId, productId);
                return;
            }
        }

        cart.UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveFromCart(string cartId, int productId)
    {
        var cart = GetCart(cartId);
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        
        if (item != null)
        {
            cart.Items.Remove(item);
            cart.UpdatedAt = DateTime.UtcNow;
        }
    }

    public void ClearCart(string cartId)
    {
        var cart = GetCart(cartId);
        cart.Items.Clear();
        cart.UpdatedAt = DateTime.UtcNow;
    }
}