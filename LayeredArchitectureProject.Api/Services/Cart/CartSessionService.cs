using LayeredArchitectureProject.Api.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace LayeredArchitectureProject.Api.Services.Cart
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public LayeredArchitectureProject.Entity.Domain.Cart.Cart GetCart()
        {
            var cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<LayeredArchitectureProject.Entity.Domain.Cart.Cart>("cart");

            if (cartToCheck != null) return cartToCheck;

            _httpContextAccessor.HttpContext.Session.SetObject("cart",new LayeredArchitectureProject.Entity.Domain.Cart.Cart());
            cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<LayeredArchitectureProject.Entity.Domain.Cart.Cart>("cart");

            return cartToCheck;
        }

        public void SetCart(LayeredArchitectureProject.Entity.Domain.Cart.Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
