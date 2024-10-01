using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class PassengerRepository
    {
        private readonly ApplicationDbContext _context;
        public PassengerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Passenger pas)
        {
            _context.Passengers.Add(pas);
            _context.SaveChanges();
            return pas.UserId;
        }
    }
}
