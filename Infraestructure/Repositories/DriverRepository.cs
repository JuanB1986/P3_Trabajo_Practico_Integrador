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

        public int Add(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return 0;                       //VER QUE SE RETORNA ACA
        }

        public List<Driver> GetAll()
        {
            return _context.Drivers.ToList();
        }
    }
}
