using Application.Models;
using Application.Models.Request;
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
        int Add(CarCreateRequest requestdto);
        IEnumerable<CarDto> GetAllCars();
        CarDto? GetCarById(int id);
        bool Update(int id, CarUpdateDto requestdto);
        bool Delete(int id);
    }
}
