using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TavelId { get; set; }
        public string StarDirection { get; set; } = string.Empty;
        public string EndDirection { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public float price { get; set; }
        public Driver Driver { get; set; }
        public ICollection<Passenger> Travels { get; set; } = new List<Passenger>();

    }
}
