using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Admin> GetAllAdmins()
        {
            var adminList = _context.Admins.ToList();
            return adminList;
        }
        public Admin? GetAdminById(int id)
        {
            var admin = _context.Admins.FirstOrDefault(admin => admin.Id == id);
            return admin;
        }
        public Admin? GetAdminByEmail(string email)
        {
            return _context.Admins.FirstOrDefault(admin => admin.Email == email);
        }
    }
}
