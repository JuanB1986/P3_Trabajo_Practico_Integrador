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
    public class TravelRepository : BaseRepository<Travel>, ITravelRepository
    {
        public TravelRepository(ApplicationDbContext context) : base(context)
        {
        }
        public IEnumerable<Travel> GetAllTravels()
        {
            var list = _context.Travels
                                   .Include(driver => driver.Driver)
                                   .Include(passenger => passenger.Passengers)
                                   .ToList();
            return list;
        }
    }
}
