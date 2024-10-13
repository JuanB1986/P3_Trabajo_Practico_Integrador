using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TravelCreateDto
    {
        [Required]
        public string StartDirection { get; set; } = string.Empty;

        [Required]
        public string EndDirection { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public int DriverId { get; set; }
    }
}
