using CorePersistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Model.Dtos.Response;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class ProductRepository : EfRepositoryBase<BaseDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }

        public List<ProductDetailDto> GetAllProductDetails()
        {
            var details = Context.Products.Join(
                Context.Coffees,
                p => p.CoffeeId,
                c => c.Id,
                (product, coffee) => new ProductDetailDto
                {
                    Id = product.Id,
                    Name= product.Name,
                    CategoryName= product.CategoryName,
                    Price= product.Price,
                    CoffeeName= coffee.Name                
                }         
                ).ToList();
            return details; 
        }

        public List<ProductDetailDto> GetDetailsByCoffeeId(int coffeeId)
        {
           var details =Context.Products.Where(x=>x.CoffeeId==coffeeId).Join(
               Context.Coffees,
               p=>p.CoffeeId,
               c=> c.Id,
               (p,c)=>new ProductDetailDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   CategoryName = p.CategoryName,
                   Price = p.Price,
                   CoffeeName = c.Name
               }
               ).ToList();
            return details;
        }

        public ProductDetailDto GetProductDetail(Guid id)
        {
            var details = Context.Products.Join(
               Context.Coffees,
               p => p.CoffeeId,
               c => c.Id,
               (p, c) => new ProductDetailDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   CategoryName = p.CategoryName,
                   Price = p.Price,
                   CoffeeName = c.Name
               }
               ).SingleOrDefault(x=>x.Id==id);

            return details;
        }
    }
}
