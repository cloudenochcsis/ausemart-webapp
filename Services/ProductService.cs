using ausemartweb.Models;

namespace ausemartweb.Services;

public class ProductService
{
    private List<Product> _products;
    private int _nextId = 1;

    public ProductService()
    {
        // Initialize with some sample products
        _products = new List<Product>
        {
            new Product
            {
                Id = _nextId++,
                Name = "Kangaroo Plush Toy",
                Description = "Soft and cuddly kangaroo plush toy, perfect for all ages.",
                Price = 24.99m,
                ImageUrl = "/images/kangaroo.jpg",
                StockQuantity = 50,
                Category = "Toys"
            },
            new Product
            {
                Id = _nextId++,
                Name = "Koala Slippers",
                Description = "Comfortable koala-themed slippers for lounging around.",
                Price = 34.99m,
                ImageUrl = "/images/koala.jpg",
                StockQuantity = 30,
                Category = "Apparel"
            },
            new Product
            {
                Id = _nextId++,
                Name = "Spider Keychain",
                Description = "Realistic spider keychain that's sure to surprise your friends!",
                Price = 12.99m,
                ImageUrl = "/images/spider.jpg",
                StockQuantity = 100,
                Category = "Accessories"
            }
        };
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> GetProductsByCategory(string category)
    {
        return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public void AddProduct(Product product)
    {
        product.Id = _nextId++;
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