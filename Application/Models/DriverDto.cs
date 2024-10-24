using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<CarDto> Cars { get; set; } = new List<CarDto>();
        public List<TravelForResponse> Travels { get; set; } = new List<TravelForResponse>();

        public static DriverDto CreateDriver(Driver driver)
        {
            var newDto = new DriverDto()
            {
                Id = driver.Id,
                Name = driver.Name,
                LastName = driver.LastName,
                PhoneNumber = driver.PhoneNumber,
                Dni = driver.Dni,
                Email = driver.Email,
                Password = driver.Password,
                //UserRole = driver.UserRole,
                Cars = driver.Cars.Select(car => CarDto.CreateCar(car)).ToList(),
                Travels = driver.Travels.Select(travel => TravelForResponse.CreateTravel(travel)).ToList()

            };
            return newDto;
        }
        public static IEnumerable<DriverDto> CreateList(IEnumerable<Driver> drivers)
        {
            return drivers.Select(travel => CreateDriver(travel)).ToList();
        }
    }
}
