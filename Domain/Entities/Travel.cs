using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        public int TavelId { get; set; }
        public string StarDirection { get; set; }
        public string EndDirection { get; set; }
        public DateTime StartTime { get; set; }
        public float price { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();

    }
}
