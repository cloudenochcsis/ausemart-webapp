using ausemartweb.Models;

namespace ausemartweb.Services;

public interface ICartService
{
    Cart GetCart(string cartId);
    void AddToCart(string cartId, int productId, int quantity = 1);
    void UpdateCartItem(string cartId, int productId, int quantity);
    void RemoveFromCart(string cartId, int productId);
    void ClearCart(string cartId);
}