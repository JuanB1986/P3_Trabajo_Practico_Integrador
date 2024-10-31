using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class DriverForTravelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Capacity { get; set; }

        public static DriverForTravelResponse CreateDriver(Driver driver)
        {
            var newDto = new DriverForTravelResponse()
            {
                Id = driver.Id,
                Name = driver.Name,
                LastName = driver.LastName,
                Capacity = driver.Cars.FirstOrDefault(car => car.IsAvailable)!.Capacity,
            };
            return newDto;
        }

    }
}
