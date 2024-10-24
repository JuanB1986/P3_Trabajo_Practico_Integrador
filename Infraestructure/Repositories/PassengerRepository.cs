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
            var passengerList = _context.Passengers
                                    .Include(passenger => passenger.Reservations)
                                    .ToList();
            return passengerList;
        }
        public Passenger? GetPassengerById(int id)
        {
            var passenger = _context.Passengers
                                    .Include(passenger => passenger.Reservations)
                                    .FirstOrDefault(passenger => passenger.Id == id);
            return passenger;
        }
        public Passenger? GetPassengerByName(string name)
        {
            return _context.Passengers
                                    .FirstOrDefault(passenger => passenger.Name == name);
        }
    }
}
