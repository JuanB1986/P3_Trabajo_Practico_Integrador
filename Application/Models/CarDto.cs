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
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Model { get; set; }
        public int Kilometers { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int Capacity { get; set; }

        public static CarDto CreateCar(Car car)
        {
            var newCar = new CarDto()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Kilometers = car.Kilometers,
                LicensePlate = car.LicensePlate,
                Capacity = car.Capacity,
            };
            return newCar;
        }
        public static IEnumerable<CarDto> CreateList(IEnumerable<Car> cars)
        {
            return cars.Select(car => CreateCar(car)).ToList();
        }
    }
}
