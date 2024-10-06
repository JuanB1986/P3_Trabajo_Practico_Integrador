using Domain.Entities;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class CarRepository
    {

        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car.CarId;
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        
    }
}
