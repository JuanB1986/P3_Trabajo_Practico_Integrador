using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class TravelForResponse
    {
        public int Id { get; set; }
        public string StartDirection { get; set; } = string.Empty;
        public string EndDirection { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public string Date => StartTime.ToString("dd-MM-yyyy");
        public string Time => StartTime.ToString("HH:mm 'hs'");
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
        public TravelStatus Status { get; set; } = TravelStatus.Pending;

        public static TravelForResponse CreateTravel(Travel travel)
        {
            int carCapacity = travel.Driver?.Cars.FirstOrDefault(c => c.IsAvailable)?.Capacity ?? 0;

            int occupiedSeats = travel.Passengers.Count;

            int availableSeats = Math.Max(carCapacity - occupiedSeats, 0);

            return new TravelForResponse
            {
                Id = travel.Id,
                StartDirection = travel.StartDirection,
                EndDirection = travel.EndDirection,
                StartTime = travel.StartTime,
                Price = travel.Price,
                Status = travel.Status,
                AvailableSeats = availableSeats
            };
        }

        public static IEnumerable<TravelForResponse> CreateList(IEnumerable<Travel> travels)
        {
            return travels.Select(travel => CreateTravel(travel)).ToList();
        }
    }
}
