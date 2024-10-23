using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarDto
    {
        public string Brand { get; set; } = string.Empty;
        public int Model { get; set; }
        public int Kilometers { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int Capacity { get; set; }

        public static CarDto CreateCar(Car car)
        {
            var newCar = new CarDto()
            {
                Brand = car.Brand,
                Model = car.Model,
                Kilometers = car.Kilometers,
                LicensePlate = car.LicensePlate,
                Capacity = car.Capacity,
            };
            return newCar;
        }
    }
}
