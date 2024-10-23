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
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User? GetUserByName(string name)
        {
            //throw new NotImplementedException();
            //return _context.Users.SingleOrDefault(p => p.Name == name);
            return null;
        }

        public User? GetUserByUserName(string userName)
        {
            //return _context.Users.SingleOrDefault(p => p.Name == userName);
            return null;
        }
    }
}
