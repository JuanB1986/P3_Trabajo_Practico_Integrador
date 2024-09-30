using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Passenger : User
    {
        public ICollection<Travel> Reservations { get; set; } = new List<Travel>();
    }
}
