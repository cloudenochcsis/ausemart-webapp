using Microsoft.AspNetCore.Mvc;
using ausemartweb.Services;

namespace ausemartweb.ViewComponents;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly CartService _cartService;

    public CartSummaryViewComponent(CartService cartService)
    {
        _cartService = cartService;
    }

    public IViewComponentResult Invoke()
    {
        var sessionId = HttpContext.Session.Id;
        var itemCount = _cartService.GetItemCount(sessionId);
        
        return View(itemCount);
    }
}