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
        //public string PhoneNumber { get; set; } = string.Empty;
        //public string Dni { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string Password { get; set; } = string.Empty;
        //public List<CarDto> Cars { get; set; } = new List<CarDto>();
        //public List<TravelDto> Travels { get; set; } = new List<TravelDto>();

        public static DriverForTravelResponse CreateDriver(Driver driver)
        {
            var newDto = new DriverForTravelResponse()
            {
                Id = driver.Id,
                Name = driver.Name,
                LastName = driver.LastName,
                //PhoneNumber = driver.PhoneNumber,
                //Dni = driver.Dni,
                //Email = driver.Email,
                //Password = driver.Password,
                //UserRole = driver.UserRole,
                //Cars = driver.Cars.Select(car => CarDto.CreateCarDto(car)).ToList(),
                //Travels = driver.Travels.Select(travel => TravelDto.CreateTravel(travel)).ToList()
            };
            return newDto;
        }

    }
}
