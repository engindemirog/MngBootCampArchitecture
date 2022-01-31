using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Color:Entity
    {
        public Color()
        {
            Cars = new HashSet<Car>();
        }

        public Color(int id,string name):this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
