using CorePersistence.Repositories;
using Model.Dtos.Response;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract;

public interface IProductRepository:IEntityRepository<Product,Guid>
{
    List<ProductDetailDto> GetAllProductDetails();
    List<ProductDetailDto> GetDetailsByCoffeeId(int coffeeId);
    ProductDetailDto GetProductDetail(Guid id);
}
