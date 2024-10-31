using Infraestructure.Data;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class BaseRepository<T> where T : class, IEntity 
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Agrega un nuevo elemento de tipo T a la base de datos.
        public int Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        // Actualiza un elemento de la base de datos.
        public bool Update(T entity)
        {
            _dbSet.Update(entity); 
            return _context.SaveChanges() > 0; 
        }

        // Elimina un elemento de la base de datos.
        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

    }
}