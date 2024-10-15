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
    public class TravelRepository : BaseRepository<Travel>, ITravelRepository
    {
        public TravelRepository(ApplicationDbContext context) : base(context) 
        {

        }
    }
}
