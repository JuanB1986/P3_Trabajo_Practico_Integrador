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
        public Driver? GetDriverWithCars(int id)
        {
            return _context.Drivers
                .Include(car => car.Cars)
                .FirstOrDefault(car => car.Id == id);
        }

        public Driver? GetDriverByName(string name)
        {
            return _context.Drivers
                .Include(car => car.Cars)
                .FirstOrDefault (car => car.Name == name);
        }

    }
}