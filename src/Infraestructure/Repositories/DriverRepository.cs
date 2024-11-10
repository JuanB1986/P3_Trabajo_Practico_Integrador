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
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Driver> GetAllDrivers()
        {
            var driverList = _context.Drivers
                                .Include(driver => driver.Cars)
                                .Include(driver => driver.Travels)
                                .ToList();
            return driverList;
        }
        public Driver? GetDriverById(int id)
        {
            return _context.Drivers
                           .Include(driver => driver.Cars)
                           .Include(driver => driver.Travels)
                               .ThenInclude(travel => travel.Passengers)
                           .FirstOrDefault(driver => driver.Id == id);
        }

        public Driver? GetDriverByEmail(string email)
        {
            return _context.Drivers
                                .Include(driver => driver.Cars)
                                .FirstOrDefault (driver => driver.Email == email);
        }
    }
}