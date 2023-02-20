using System;
using System.Collections.Generic;
using System.Linq;
using CaliperApi.Domain.Helpers;
using CaliperApi.Domain.Models;

namespace CaliperApi.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Find(int id);
        Product CreateProduct(ProductDto ProductDto);
        ProductDto ToProductDto(Product Product);
        Product GetProduct(int id);

    }

    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product Find(int id)
        {
            return _context.Products.Find(id);
        }

        public Product CreateProduct(ProductDto ProductDto)
        {   
            var Product = ToProduct(ProductDto);
            _context.Products.Add(Product);
            this._context.SaveChanges();
            return Product;
        }

        private Product ToProduct(ProductDto ProductDto)
        {
            return new Product
            {   

                productname= ProductDto.productname,
                description = ProductDto.description,
                type= ProductDto.type,
                price = ProductDto.price,
                quantity = ProductDto.quantity,
                
            };
        }

        public ProductDto ToProductDto(Product Product)
        {
            return new ProductDto
            {
                id= Product.id,
                productname= Product.productname,
                description = Product.description,
                type= Product.type,
                price = Product.price,
                quantity = Product.quantity,
            };
        }
        
          public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
         public List<Product> GetALL()
        {
            return _context.Products.ToList();
        }
    }
}