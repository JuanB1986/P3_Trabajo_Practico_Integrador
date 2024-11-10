using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        //public string Email { get; set; } = string.Empty;
        //public string Password { get; set; } = string.Empty;
        

        public static AdminDto CreateAdmin(Admin admin)
        {
            var newDto = new AdminDto()
            {
                Id = admin.Id,
                Name = admin.Name,
                LastName = admin.LastName,
                PhoneNumber = admin.PhoneNumber,
                Dni = admin.Dni,
                //Email = admin.Email,
                //Password = admin.Password,

            };
            return newDto;
        }

        public static IEnumerable<AdminDto> CreateList(IEnumerable<Admin> admins)
        {
            return admins.Select(admin => CreateAdmin(admin)).ToList();
        }
    }
}
