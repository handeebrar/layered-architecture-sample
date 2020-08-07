using System.Collections.Generic;
using System.Linq;

namespace LayeredArchitectureProject.Entity.Domain.Cart
{
    public class Cart : AuditableEntity
    {
        public Cart()
        {
            CartItems = new List<CartItem>(); //there is no product in the card
        }

        public List<CartItem> CartItems { get; set; }
        public decimal TotalAmount
        {
            get { return (decimal) CartItems.Sum(cartItem => cartItem.Product.UnitPrice * cartItem.Quantity); }
        }
    }
}
