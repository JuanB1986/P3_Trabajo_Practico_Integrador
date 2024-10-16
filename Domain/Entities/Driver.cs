using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Driver : User
    {
        public List<Car> Cars { get; set; } = new List<Car>();
        public List<Travel> Travel { get; set; } = new List<Travel>();
    }
}