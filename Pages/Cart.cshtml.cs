using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages;

public class CartModel : PageModel
{
    private readonly ILogger<CartModel> _logger;
    private readonly ICartService _cartService;
    
    public Cart UserCart { get; set; } = new Cart();

    public CartModel(ILogger<CartModel> logger, ICartService cartService)
    {
        _logger = logger;
        _cartService = cartService;
    }

    public void OnGet()
    {
        var cartId = HttpContext.Session.GetCartId();
        UserCart = _cartService.GetCart(cartId);
    }
    
    public IActionResult OnPostUpdateItem(int productId, int quantity)
    {
        var cartId = HttpContext.Session.GetCartId();
        _cartService.UpdateCartItem(cartId, productId, quantity);
        return RedirectToPage();
    }
    
    public IActionResult OnPostRemoveItem(int productId)
    {
        var cartId = HttpContext.Session.GetCartId();
        _cartService.RemoveFromCart(cartId, productId);
        return RedirectToPage();
    }
    
    public IActionResult OnPostClearCart()
    {
        var cartId = HttpContext.Session.GetCartId();
        _cartService.ClearCart(cartId);
        return RedirectToPage();
    }
    
    public IActionResult OnPostCheckout()
    {
        // In a real implementation, this would process the order
        // For now, we'll just clear the cart to simulate a completed order
        var cartId = HttpContext.Session.GetCartId();
        _cartService.ClearCart(cartId);
        
        // Redirect to a thank you page or order confirmation
        TempData["OrderSuccess"] = "Your order has been placed successfully!";
        return RedirectToPage("/Index");
    }
}

