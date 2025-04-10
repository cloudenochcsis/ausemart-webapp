using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages;

public class ProductsModel : PageModel
{
    private readonly ILogger<ProductsModel> _logger;
    private readonly ProductService _productService;
    private readonly CartService _cartService;

    public ProductsModel(
        ILogger<ProductsModel> logger,
        ProductService productService,
        CartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    
    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    public void OnGet()
    {
        if (string.IsNullOrEmpty(Category))
        {
            Products = _productService.GetProducts();
        }
        else
        {
            Products = _productService.GetProductsByCategory(Category);
        }
    }
    
    public IActionResult OnPostAddToCart(int productId, int quantity = 1)
    {
        string sessionId = HttpContext.Session.Id;
        _cartService.AddToCart(sessionId, productId, quantity);
        
        return RedirectToPage();
    }
}
