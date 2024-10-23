using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TravelDto
    {
        public int Id { get; set; }
        public string StartDirection { get; set; } = string.Empty;
        public string EndDirection { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public DriverForTravelResponse Driver { get; set; } = new DriverForTravelResponse(); 
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public TravelStatus Status { get; set; } = TravelStatus.Pending;

        public static TravelDto CreateTravel(Travel travel)
        {
            return new TravelDto
            {
                Id = travel.Id,
                StartDirection = travel.StartDirection,
                EndDirection = travel.EndDirection,
                StartTime = travel.StartTime,
                Price = travel.Price,
                Driver = DriverForTravelResponse.CreateDriver(travel.Driver),
                Passengers = travel.Passengers,
                Status = travel.Status
            };
        }

        public static IEnumerable<TravelDto> CreateList(IEnumerable<Travel> travels)
        {
            return travels.Select(travel => CreateTravel(travel)).ToList();
        }
    }
}

