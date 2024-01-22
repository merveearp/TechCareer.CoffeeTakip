using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Request
{
    public record UpdateCoffeeRequest(int Id ,string Name, string Adress, decimal CoffeePoint)
    {
        public static Coffee ConvertToEntity(UpdateCoffeeRequest request)
        {
            return new Coffee
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Adress,
                CoffeePoint = request.CoffeePoint
            };
        }
    }
}
