using Model.Dtos.Request;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Response;

 public record CoffeeResponse(int Id, string Name, string Adress, decimal CoffeePoint)
{
    public static CoffeeResponse ConvertToResponse(Coffee coffee)
    {
        return new CoffeeResponse
        (
            Id : coffee.Id,
            Name : coffee.Name,
            Adress : coffee.Address,
            CoffeePoint:coffee.CoffeePoint

        );
    }


}
