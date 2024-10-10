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
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _context;
        public PassengerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Passenger> GetAllPassenger()
        {
            return _context.Passengers.ToList();
        }

        public int AddPassenger(Passenger passenger)
        {
            _context.Passengers.Add(passenger);
            _context.SaveChanges();
            return passenger.UserId;
        }

        public bool DeletePassenger(int id)
        {
            var passenger = _context.Passengers.FirstOrDefault(x => x.UserId == id);

            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
                return true; 
            }

            return false;
        }


    }
}
