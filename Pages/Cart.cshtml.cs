using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages;

public class CartModel : PageModel
{
    private readonly ILogger<CartModel> _logger;
    private readonly CartService _cartService;

    public CartModel(ILogger<CartModel> logger, CartService cartService)
    {
        _logger = logger;
        _cartService = cartService;
    }

    public List<CartItem> CartItems { get; set; } = new();
    public decimal CartTotal { get; set; }

    public void OnGet()
    {
        string sessionId = HttpContext.Session.Id;
        CartItems = _cartService.GetCart(sessionId);
        CartTotal = _cartService.GetCartTotal(sessionId);
    }

    public IActionResult OnPostUpdateQuantity(int cartItemId, int quantity)
    {
        string sessionId = HttpContext.Session.Id;
        _cartService.UpdateCartItem(sessionId, cartItemId, quantity);
        return RedirectToPage();
    }

    public IActionResult OnPostRemoveItem(int cartItemId)
    {
        string sessionId = HttpContext.Session.Id;
        _cartService.RemoveCartItem(sessionId, cartItemId);
        return RedirectToPage();
    }

    public IActionResult OnPostClearCart()
    {
        string sessionId = HttpContext.Session.Id;
        _cartService.ClearCart(sessionId);
        return RedirectToPage();
    }

    public IActionResult OnPostCheckout()
    {
        string sessionId = HttpContext.Session.Id;
        _cartService.Checkout(sessionId);
        return RedirectToPage("/Checkout/Success");
    }
}

