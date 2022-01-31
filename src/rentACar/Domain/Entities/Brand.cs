using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand:Entity
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public Brand(int id, string name):this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public virtual ICollection<Model> Models{ get; set; }
    }
}
