using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int Model { get; set; }
        public int Kilometers { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
    }
}
