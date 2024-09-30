using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Driver : User
    {
        public ICollection<Car> Cars { get; set; } = new List<Car>();
        public ICollection<Travel> Travels { get; set; } = new List<Travel>();
    }
}
