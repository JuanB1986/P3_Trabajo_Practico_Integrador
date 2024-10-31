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
        public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
