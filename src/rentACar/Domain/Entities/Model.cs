using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model:Entity
    {
        public Model()
        {
        }

        public Model(int id, string name, double dailyPrice, int transmissionId, int fuelId, int brandId, string imageUrl):this()
        {
            Id = id;
            Name = name;
            DailyPrice = dailyPrice;
            TransmissionId = transmissionId;
            FuelId = fuelId;
            BrandId = brandId;
            ImageUrl = imageUrl;
        }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public double  DailyPrice { get; set; }     
        public string ImageUrl { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual Fuel Fuel { get; set; }
        public virtual ICollection<Car> Cars { get; set; }


    }
}
