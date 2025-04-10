using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages;

public class ProductsModel : PageModel
{
    private readonly ILogger<ProductsModel> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public List<Product> Products { get; set; } = new List<Product>();
    public List<string> Categories { get; set; } = new List<string>();
    public string? CategoryFilter { get; set; }
    public string? SortOrder { get; set; }
    public string? SearchQuery { get; set; }

    public ProductsModel(
        ILogger<ProductsModel> logger,
        IProductService productService,
        ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    public void OnGet(string? category, string? sortOrder, string? search)
    {
        CategoryFilter = category;
        SortOrder = sortOrder;
        SearchQuery = search;
        
        // Get all products or filter by category
        Products = string.IsNullOrEmpty(category) 
            ? _productService.GetAllProducts() 
            : _productService.GetProductsByCategory(category);
        
        // Apply search if provided
        if (!string.IsNullOrEmpty(search))
        {
            Products = Products.Where(p => 
                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || 
                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        // Apply sorting
        Products = sortOrder switch
        {
            "price_asc" => Products.OrderBy(p => p.Price).ToList(),
            "price_desc" => Products.OrderByDescending(p => p.Price).ToList(),
            "newest" => Products.OrderByDescending(p => p.Id).ToList(),
            _ => Products.OrderBy(p => p.Name).ToList()
        };
        
        // Get all categories
        Categories = _productService.GetCategories();
    }
    
    public IActionResult OnPostAddToCart(int productId, int quantity = 1)
    {
        var cartId = HttpContext.Session.GetCartId();
        _cartService.AddToCart(cartId, productId, quantity);
        return RedirectToPage();
    }
}
