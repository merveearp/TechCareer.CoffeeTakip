using CorePersistence.EntityBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Coffee:Entity<int>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal CoffeePoint { get; set; }

    public List<Product> Products { get; set; }
   

}
