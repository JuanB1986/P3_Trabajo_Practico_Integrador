using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        //public List<int> ReservationsIDs { get; set; } = new List<int>();

        public List<Travel> Reservations { get; set; } = new List<Travel>();
    }
}
