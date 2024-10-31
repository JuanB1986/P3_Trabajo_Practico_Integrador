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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Car> GetAllCars()
        {
            var carList = _context.Cars.ToList();
            return carList;
        }
        public Car? GetCarById(int id)
        {
            var car = _context.Cars.FirstOrDefault(car => car.Id == id);
            return car;
        }
    }
}