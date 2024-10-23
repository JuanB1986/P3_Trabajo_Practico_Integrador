using Domain.Interfaces;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class EfRepository<T> : BaseRepository<T> where T : class, IEntity
    {
        protected readonly ApplicationDbContext _context;
        public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
