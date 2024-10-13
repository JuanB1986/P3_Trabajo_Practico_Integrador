using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Driver : User
    {
        public List<int> CarsId { get; set; } = new List<int>();
        public List<int> TravelIds { get; set; } = new List<int>();
    }
}