using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly ApplicationDbContext _context;
        public TravelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Travel item)
        {
            _context.Travels.Add(item);
            _context.SaveChanges();
            return item.TavelId;
        }

        public List<Travel> GetAll()
        {
            return _context.Travels.ToList();
        }
    }
}
