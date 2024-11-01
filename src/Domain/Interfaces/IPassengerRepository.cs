using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPassengerRepository : IBaseRepository<Passenger> 
    {
        IEnumerable<Passenger> GetAllPassengers();
        Passenger? GetPassengerById(int id);
        Passenger? GetPassengerByName(string Name);
    }

}