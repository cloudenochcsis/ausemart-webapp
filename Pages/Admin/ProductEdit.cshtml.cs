using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ausemartweb.Models;
using ausemartweb.Services;

namespace ausemartweb.Pages.Admin;

public class ProductEditModel : PageModel
{
    private readonly ProductService _productService;

    public ProductEditModel(ProductService productService)
    {
        _productService = productService;
    }

    [BindProperty]
    public Product Product { get; set; } = new();

    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            var existingProduct = _productService.GetProductById(id.Value);
            if (existingProduct == null)
            {
                return NotFound();
            }
            Product = existingProduct;
        }
        
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (Product.Id == 0)
        {
            _productService.AddProduct(Product);
        }
        else
        {
            _productService.UpdateProduct(Product);
        }

        return RedirectToPage("./Products");
    }
}