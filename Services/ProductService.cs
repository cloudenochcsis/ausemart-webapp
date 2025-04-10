using ausemartweb.Models;

namespace ausemartweb.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        // Initialize with sample products
        _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Kangaroo Plush Toy",
                Description = "Adorable kangaroo plush toy, perfect for children of all ages.",
                Price = 29.99m,
                ImageUrl = "/images/kangaroo.jpg",
                Category = "Souvenirs",
                IsFeatured = true,
                Attributes = new Dictionary<string, string>
                {
                    { "Size", "Medium" },
                    { "Color", "Brown" }
                }
            },
            new Product
            {
                Id = 2,
                Name = "Koala Keychain",
                Description = "Cute koala keychain made from high-quality materials.",
                Price = 12.99m,
                ImageUrl = "/images/koala.jpg",
                Category = "Souvenirs",
                IsFeatured = true,
                Attributes = new Dictionary<string, string>
                {
                    { "Material", "Metal" },
                    { "Type", "Keyring" }
                }
            },
            new Product
            {
                Id = 3,
                Name = "Spider Fridge Magnet",
                Description = "Realistic spider fridge magnet that will surprise your guests.",
                Price = 8.99m,
                ImageUrl = "/images/spider.jpg",
                Category = "Souvenirs",
                IsFeatured = false,
                Attributes = new Dictionary<string, string>
                {
                    { "Material", "Resin" },
                    { "Size", "Small" }
                }
            },
            new Product
            {
                Id = 4,
                Name = "Aussie Vegemite",
                Description = "Authentic Australian Vegemite spread, a must-try for food enthusiasts.",
                Price = 15.50m,
                ImageUrl = "/images/kangaroo.jpg",
                Category = "Food & Drinks",
                IsFeatured = true,
                Attributes = new Dictionary<string, string>
                {
                    { "Weight", "220g" },
                    { "Expiry", "12 months" }
                }
            },
            new Product
            {
                Id = 5,
                Name = "Australian Flag T-Shirt",
                Description = "Comfortable cotton T-shirt featuring the Australian flag.",
                Price = 24.99m,
                ImageUrl = "/images/koala.jpg",
                Category = "Clothing",
                IsFeatured = true,
                IsOnSale = true,
                Attributes = new Dictionary<string, string>
                {
                    { "Size", "M/L/XL" },
                    { "Material", "Cotton" }
                }
            },
            new Product
            {
                Id = 6,
                Name = "Boomerang",
                Description = "Traditional wooden boomerang with authentic Aboriginal art.",
                Price = 49.99m,
                ImageUrl = "/images/spider.jpg",
                Category = "Souvenirs",
                IsFeatured = true,
                Attributes = new Dictionary<string, string>
                {
                    { "Material", "Wood" },
                    { "Length", "30cm" }
                }
            }
        };
    }

    public List<Product> GetAllProducts() => _products;

    public Product? GetProductById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public List<Product> GetProductsByCategory(string category) => 
        _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<string> GetCategories() => 
        _products.Select(p => p.Category).Distinct().ToList();

    public void AddProduct(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            var index = _products.IndexOf(existingProduct);
            _products[index] = product;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}