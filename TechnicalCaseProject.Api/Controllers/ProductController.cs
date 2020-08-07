using System.Collections.Generic;
using LayeredArchitectureProject.Entity.Domain.Product;
using LayeredArchitectureProject.Service;
using LayeredArchitectureProject.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitectureProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetProductList")]
        public ReturnModel<List<Product>> Get()
        {
            return _service.GetAll();
        }

    }
}
