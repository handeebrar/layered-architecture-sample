using System.Collections.Generic;
using LayeredArchitectureProject.Entity.Domain.Cart;

namespace LayeredArchitectureProject.Service.Cart
{
    public interface ICartService : ISave
    {
        ReturnModel<string> AddToCart (Entity.Domain.Cart.Cart cart , Entity.Domain.Product.Product product , int quantity);
        ReturnModel<List<CartItem>> ListCart (Entity.Domain.Cart.Cart cart);
    }
}
