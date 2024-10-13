using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Travel : IEntity
    {
        public int Id { get; set; }
        public string StartDirection { get; set; } = string.Empty;
        public string EndDirection { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public int DriverId { get; set; }
        public List<int> PassengerlIds { get; set; } = new List<int>();
        public TravelStatus Status { get; set; } = TravelStatus.Pending;
    }
}