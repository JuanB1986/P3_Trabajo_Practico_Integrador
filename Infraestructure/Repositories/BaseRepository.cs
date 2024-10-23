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

        // Devuelve una lista con todos los elementos de tipo T.
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Busca un elemento de tipo T por su ID.
        public T GetById(int Id)
        {
            var entity = _dbSet.Find(Id);
            if (entity == null)
            {
                throw new InvalidOperationException($"No element was found with ID {Id}");
            }
            return entity;
        }

        // Agrega un nuevo elemento de tipo T a la base de datos.
        public int Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        // Elimina un elemento de la base de datos.
        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        // Actualiza un elemento de la base de datos.
        public bool Update(T entity)
        {
            _dbSet.Update(entity); 
            return _context.SaveChanges() > 0; 
        }
    }
}