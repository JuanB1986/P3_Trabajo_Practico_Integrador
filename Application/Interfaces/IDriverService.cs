using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDriverService
    {
        int Add(DriverCreateDto driverDto);
        List<Driver> GetAll();
        Driver GetById(int Id);
        bool Update(int Id, DriverUpdateDto requestDto);
        bool Delete(int Id);
    }
}
