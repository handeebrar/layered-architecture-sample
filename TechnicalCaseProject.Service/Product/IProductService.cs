using System.Collections.Generic;

namespace LayeredArchitectureProject.Service.Product
{
    public interface IProductService
    {
        ReturnModel<Entity.Domain.Product.Product> Get(int productId);
        ReturnModel<List<Entity.Domain.Product.Product>> GetAll();
    }
}
