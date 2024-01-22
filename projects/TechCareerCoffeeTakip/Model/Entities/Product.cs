using CorePersistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Product:Entity<Guid>
{
          
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
    public int CoffeeId { get; set; }
    public Coffee Coffee { get; set; } 
    
    
    


}
