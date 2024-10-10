using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPassengerService
    {
        public List<Passenger> Get();
        public int Add(PassengerCreateRequestDto requestdto);
        public bool Delete(int id);
    }
}
