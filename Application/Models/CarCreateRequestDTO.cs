using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CarCreateRequestDTO
    {
        [Required] public string Brand { get; set; }
        [Required] public int Model { get; set; }
        [Required] public int Kilometers { get; set; }
        [Required] public string LicensePlate { get; set; }
        [Required] public bool IsAvailable { get; set; }
        [Required] public int Capacity { get; set; }
    }
}
