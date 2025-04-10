namespace ausemartweb.Models;

public class Cart
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);
    public decimal ShippingCost => Items.Any() ? 5.99m : 0;
    public decimal Tax => Math.Round(Subtotal * 0.1m, 2);
    public decimal Total => Subtotal + ShippingCost + Tax;
}