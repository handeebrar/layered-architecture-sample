namespace LayeredArchitectureProject.Entity.Domain.Cart
{
    public class CartItem
    {
        public Product.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
