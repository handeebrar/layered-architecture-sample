namespace LayeredArchitectureProject.Api.Services.Cart
{
    public interface ICartSessionService
    {
        LayeredArchitectureProject.Entity.Domain.Cart.Cart GetCart(); //read from session
        void SetCart(LayeredArchitectureProject.Entity.Domain.Cart.Cart cart); //write to session
    }
}
