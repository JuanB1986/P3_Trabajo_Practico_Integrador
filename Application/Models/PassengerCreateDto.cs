﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class PassengerCreateDto
    {
        [Required] 
        public string Name { get; set; } = string.Empty;
        [Required] 
        public string LastName { get; set; } = string.Empty;
        [Required] 
        public string PhoneNumber { get; set; } = string.Empty;
        [Required] 
        public string Dni { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required] 
        public string Password { get; set; } = string.Empty;
    }
}