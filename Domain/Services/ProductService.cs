using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;
using CaliperApi.Domain.Repositories;

namespace CaliperApi.Domain.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
        List<ProductDto> GetALl();
        Product CreateProduct(ProductDto ProductDto);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;    
        }
        
       
        public Product GetProduct(int id)
        {
            return _ProductRepository.GetProduct(id);
        }

        public Product CreateProduct(ProductDto ProductDto)
        {
            return _ProductRepository.CreateProduct(ProductDto);
        }
        public List<ProductDto> GetALl()
        {
            return _ProductRepository.GetAll().Select(_ProductRepository.ToProductDto).ToList();
        }
      
       
    }
}