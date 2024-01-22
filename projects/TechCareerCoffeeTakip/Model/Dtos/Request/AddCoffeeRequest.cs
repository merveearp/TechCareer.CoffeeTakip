using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.Request;

public record AddCoffeeRequest(string Name,string Adress,decimal CoffeePoint )
{
    public static Coffee ConvertToEntity(AddCoffeeRequest request)
    {
        return new Coffee
        {
            
            Name = request.Name,
            Address = request.Adress,
            CoffeePoint = request.CoffeePoint
        };
    }
}
