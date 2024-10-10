using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class DriverRepository
    {

        private readonly ApplicationDbContext _context;
        public DriverRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Driver> GetAllDriver()
        {
            return _context.Drivers.ToList();
        }

        public int AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return driver.UserId;
        }

        public bool DeleteDriver(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(x => x.UserId == id);

            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
