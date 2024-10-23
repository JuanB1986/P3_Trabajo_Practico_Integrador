using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class TravelForResponse
    {
        public int Id { get; set; }
        public TravelStatus Status { get; set; } = TravelStatus.Pending;

        public static TravelForResponse CreateTravel(Travel travel)
        {
            return new TravelForResponse
            {
                Id = travel.Id,
                Status = travel.Status
            };
        }
    }
}
