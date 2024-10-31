using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class PassengerForTravelResponse
    {
        public int Id { get; set; }
        public static PassengerForTravelResponse CreatePassenger(Passenger passenger)
        {
            var newDto = new PassengerForTravelResponse()
            {
                Id = passenger.Id,
            };
            return newDto;
        }
    }
}
