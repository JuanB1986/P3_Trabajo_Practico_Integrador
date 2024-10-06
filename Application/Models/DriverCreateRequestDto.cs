﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class DriverCreateRequestDto
    {
        [Required] public int UserId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public string Dni { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public ICollection<Car> Cars { get; set; }
        [Required] public ICollection<Travel> Travels { get; set; }
    }
}
