using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        int Add(AdminCreateDto requestdto);
        IEnumerable<AdminDto> GetAllAdmins();
        AdminDto? GetAdminById(int id);
        bool Update(int id, AdminUpdateDto requestDto);
        bool Delete(int id);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}
