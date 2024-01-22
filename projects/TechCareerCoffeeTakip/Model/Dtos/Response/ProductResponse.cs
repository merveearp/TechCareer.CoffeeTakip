using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Response;

public record ProductResponse(Guid Id, string Name, string CategoryName, decimal Price, int CoffeeId)
{
    public static ProductResponse ConvertToResponse (Product product)
    {

        return new ProductResponse(
      Id :product.Id,
      Name : product.Name,
      CategoryName : product.CategoryName,
      Price : product.Price,
      CoffeeId : product.CoffeeId

            );
    }
}
