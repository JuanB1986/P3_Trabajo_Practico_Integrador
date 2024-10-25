using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class DriverForTravelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public static DriverForTravelResponse CreateDriver(Driver driver)
        {
            var newDto = new DriverForTravelResponse()
            {
                Id = driver.Id,
                Name = driver.Name,
                LastName = driver.LastName,
            };
            return newDto;
        }

    }
}
