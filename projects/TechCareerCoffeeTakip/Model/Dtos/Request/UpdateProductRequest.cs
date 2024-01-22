using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Request
{
    public record UpdateProductRequest(Guid Id, string Name, string CategoryName, decimal Price, int CoffeeId)
    {

        public static Product ConvertToEntity(UpdateProductRequest request)
        {
            return new Product
            {
                Id = request.Id,
                Name = request.Name,
                CategoryName = request.CategoryName,
                Price = request.Price,
                CoffeeId = request.CoffeeId
            };
        }

    }
    
}
