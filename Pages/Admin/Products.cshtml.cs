using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages.Admin;

public class ProductsModel : PageModel
{
    private readonly ILogger<ProductsModel> _logger;
    private readonly IProductService _productService;
    
    public List<Product> Products { get; set; } = new List<Product>();
    public List<string> Categories { get; set; } = new List<string>();

    public ProductsModel(ILogger<ProductsModel> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetAllProducts();
        Categories = _productService.GetCategories();
    }
    
    public IActionResult OnPostAddProduct(string name, string description, decimal price, 
        string imageUrl, string category, bool isFeatured, bool isOnSale)
    {
        var product = new Product
        {
            Name = name,
            Description = description,
            Price = price,
            ImageUrl = imageUrl,
            Category = category,
            IsFeatured = isFeatured,
            IsOnSale = isOnSale,
            Attributes = new Dictionary<string, string>()
        };
        
        _productService.AddProduct(product);
        
        TempData["SuccessMessage"] = "Product has been added successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostUpdateProduct(int id, string name, string description, decimal price, 
        string imageUrl, string category, bool isFeatured, bool isOnSale)
    {
        var product = _productService.GetProductById(id);
        
        if (product == null)
        {
            return NotFound();
        }
        
        product.Name = name;
        product.Description = description;
        product.Price = price;
        product.ImageUrl = imageUrl;
        product.Category = category;
        product.IsFeatured = isFeatured;
        product.IsOnSale = isOnSale;
        
        _productService.UpdateProduct(product);
        
        TempData["SuccessMessage"] = "Product has been updated successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostDeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        
        TempData["SuccessMessage"] = "Product has been deleted successfully!";
        return RedirectToPage();
    }
}