using System;
using System.Collections.Generic;
using LayeredArchitectureProject.Data.Infrastructure.Repository;
using LayeredArchitectureProject.Data.Infrastructure.UnitOfWork;

namespace LayeredArchitectureProject.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Entity.Domain.Product.Product> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Entity.Domain.Product.Product> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.Domain.Product.Product> Get(int productId)
        {

            var result = new ReturnModel<Entity.Domain.Product.Product>();
            try
            {
                result.Data = _repository.Get(x => x.Id == productId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public ReturnModel<List<Entity.Domain.Product.Product>> GetAll()
        {
            var result = new ReturnModel<List<Entity.Domain.Product.Product>>();
            try
            {
                result.Data = _repository.GetList();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
