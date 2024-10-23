using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        Driver? GetDriverWithCars(int id);
        Driver? GetDriverByName(string name);
        IEnumerable<Driver> GetAllDrivers();
        Driver? GetDriverById(int Id);

    }
}
