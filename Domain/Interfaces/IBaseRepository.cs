using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T entity);
        List<T> GetAll();
        T GetById(int Id);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
