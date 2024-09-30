using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public int Kilometers { get; set; }
        public string LicensePlate { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
    }
}
