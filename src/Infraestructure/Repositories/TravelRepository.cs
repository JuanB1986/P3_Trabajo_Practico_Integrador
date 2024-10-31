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
            var travelList = _context.Travels
                                    .Include(travel => travel.Driver)
                                    .ThenInclude(d => d!.Cars)
                                    .Include(travel => travel.Passengers)
                                    .ToList();
            return travelList;
        }
        public Travel? GetTravelById(int id)
        {
            var travel = _context.Travels
                                    .Include(travel => travel.Driver)
                                    .ThenInclude(d => d!.Cars)
                                    .Include(travel => travel.Passengers)
                                    .FirstOrDefault(travel => travel.Id == id);
            return travel;
        }
    }
}
