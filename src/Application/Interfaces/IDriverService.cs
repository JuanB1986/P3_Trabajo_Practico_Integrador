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
    public interface IDriverService
    {
        int Add(DriverCreateRequest driverDto);
        IEnumerable<DriverDto> GetAllDrivers();
        DriverDto? GetDriverById(int id);
        bool Update(int id, DriverUpdateDto requestDto);
        bool Delete(int id);
    }
}
