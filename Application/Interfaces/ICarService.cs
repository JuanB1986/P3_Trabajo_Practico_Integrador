using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarService
    {
        int Add(CarCreateDto requestdto);
        List<Car> GetAll();
        Car GetById(int Id);
        bool Update(int Id, CarUpdateDto requestdto);
        bool Delete(int Id);
    }
}
