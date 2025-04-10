using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages.Admin;

public class AdminProductsModel : PageModel
{
    private readonly ProductService _productService;

    public AdminProductsModel(ProductService productService)
    {
        _productService = productService;
    }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public void OnGet()
    {
        Products = _productService.GetProducts();
    }

    public IActionResult OnPostDelete(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToPage();
    }
}