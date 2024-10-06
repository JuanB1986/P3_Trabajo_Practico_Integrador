using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TravelCreateRequestDTO
    {
        [Required]
        public int TavelId { get; set; }

        [Required]
        public string StarDirection { get; set; }

        [Required]
        public string EndDirection { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public Driver Driver { get; set; }
    }
}
