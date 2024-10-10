using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDriverRepository
    {
        public List<Driver> GetAllDriver();
        public int AddDriver(Driver driver);
        public bool DeleteDriver(int id);

    }
}
