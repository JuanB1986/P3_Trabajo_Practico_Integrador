using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<TravelForResponse> Reservations { get; set; } = new List<TravelForResponse>();

        public static PassengerDto CreatePassenger(Passenger passenger)
        {
            var newDto = new PassengerDto()
            {
                Id = passenger.Id,
                Name = passenger.Name,
                LastName = passenger.LastName,
                PhoneNumber = passenger.PhoneNumber,
                Dni = passenger.Dni,
                Email = passenger.Email,
                Password = passenger.Password,
                Reservations = passenger.Reservations.Select(travel => TravelForResponse.CreateTravel(travel)).ToList()

            };
            return newDto;
        }

        public static IEnumerable<PassengerDto> CreateList(IEnumerable<Passenger> passengers)
        {
            return passengers.Select(passenger => CreatePassenger(passenger)).ToList();
        }
    }
}
