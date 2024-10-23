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
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        public PassengerRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Passenger> GetAllPassengers()
        {
            var list = _context.Passengers
                                      .Include(travel => travel.Reservations)
                                      .ToList();
            return list;
        }
        public Passenger? GetPassengerById(int Id)
        {
            return _context.Passengers
                                  .Include(travel => travel.Reservations)
                                  .FirstOrDefault(travel => travel.Id == Id);
        }

        public Passenger? GetPassengerByName(string name)
        {
            return _context.Passengers
                .FirstOrDefault(passenger => passenger.Name == name);
        }

    }
}
