using System;
using System.Collections.Generic;
using System.Linq;
using LayeredArchitectureProject.Data.Infrastructure.Repository;
using LayeredArchitectureProject.Data.Infrastructure.UnitOfWork;
using LayeredArchitectureProject.Entity.Domain.Cart;
using LayeredArchitectureProject.Service.Product;

namespace LayeredArchitectureProject.Service.Cart
{
    public class CartService : ICartService
    {

        private readonly IRepository<Entity.Domain.Cart.Cart> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public CartService(IRepository<Entity.Domain.Cart.Cart> repository, IUnitOfWork unitOfWork, IProductService productService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        public ReturnModel<string> AddToCart(Entity.Domain.Cart.Cart cart, Entity.Domain.Product.Product product, int quantity)
        {
            var result = new ReturnModel<string>();

            try
            {
                //product accessibility control
                if (product == null)
                {
                    result.Data = $"No products to add to the cart were found!";
                    result.IsSuccess = false;
                }
                else
                {
                    var productToBeAdded = _productService.Get(product.Id).Data;
                    var isEnoughStock = quantity <= productToBeAdded.UnitsInStock;

                    //stock control
                    if (isEnoughStock)
                    {
                        var cartItem = cart.CartItems.FirstOrDefault(c => c.Product.Id == product.Id);

                        if (cartItem != null) //product has already been added to the card
                        {
                            cartItem.Quantity += quantity;
                            result.Data = $"{quantity} of {product.DisplayName} added to the card!";
                        }
                        else //product has never been added to the card
                        {
                            cart.CartItems.Add(new CartItem {Product = product, Quantity = quantity});
                            result.Data = $"{quantity} of {product.DisplayName} added to the card!";
                        }
                    }
                    else //the product stock is less than quantity
                    {
                        result.Data =
                            $"Only {productToBeAdded.UnitsInStock} of {product.DisplayName} can be added to the card!";
                        result.IsSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public ReturnModel<List<CartItem>> ListCart(Entity.Domain.Cart.Cart cart)
        {
            var result = new ReturnModel<List<CartItem>>();
            try
            {
                result.Data = cart.CartItems;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

    }
}
