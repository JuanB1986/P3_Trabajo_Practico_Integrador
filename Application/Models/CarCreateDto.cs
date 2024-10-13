using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarCreateDto
    {
        [Required] 
        public string Brand { get; set; } = string.Empty;
        [Required] 
        public int Model { get; set; }
        [Required] 
        public int Kilometers { get; set; }
        [Required] 
        public string LicensePlate { get; set; } = string.Empty;
        [Required] 
        public int Capacity { get; set; }
    }
}
