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
        int Add(PassengerCreateDto requestdto);
        List<Passenger> GetAll();
        Passenger GetById(int Id);
        bool Update(int Id, PassengerUpdateDto requestDto);
        bool Delete(int Id);
    }
}
