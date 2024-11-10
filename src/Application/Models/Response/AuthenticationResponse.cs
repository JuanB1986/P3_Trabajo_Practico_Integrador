using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Response
{
    public class AuthenticationResponse
    {
        public string Token { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
