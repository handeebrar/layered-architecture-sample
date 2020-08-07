using LayeredArchitectureProject.Api.Services.Cart;
using LayeredArchitectureProject.Entity.Request.Cart;
using LayeredArchitectureProject.Entity.Response.Cart;
using LayeredArchitectureProject.Service;
using LayeredArchitectureProject.Service.Cart;
using LayeredArchitectureProject.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitectureProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ICartSessionService _cartSessionService;

        public CartController(ICartService cartService, IProductService productService, ICartSessionService cartSessionService)
        {
            _cartService = cartService;
            _productService = productService;
            _cartSessionService = cartSessionService;
        }


        [HttpPost("AddToCart")]
        public ReturnModel<string> Post([FromBody] AddToCartRequestModel model)
        {

            var productToBeAdded = _productService.Get(model.ProductId).Data;
            var cart = _cartSessionService.GetCart();
            var result = _cartService.AddToCart(cart , productToBeAdded , model.Quantity);

            _cartSessionService.SetCart(cart);

            return result;
        }

        [HttpGet("GetCartSummary")]
        public CartSummaryResponseModel List()
        {
            var cart = _cartSessionService.GetCart();
            var cartSummary = new CartSummaryResponseModel { Cart = cart };

            return cartSummary;
        }
    }
}
