using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePersistence.EntityBaseModel;

public class Entity<TId>
{
public TId Id { get; set; }

}
