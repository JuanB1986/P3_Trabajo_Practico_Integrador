using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class CarUpdateDto
    {
        public string Brand { get; set; } = string.Empty;
        public int Model { get; set; }
        public int Kilometers { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
