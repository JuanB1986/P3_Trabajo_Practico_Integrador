using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ICarRepository _carRepository;

        public DriverService(IDriverRepository driverRepository, ICarRepository carRepository)
        {
            _driverRepository = driverRepository;
            _carRepository = carRepository;
        }
        // CREATE
        public int Add(DriverCreateRequest requestDto)
        {
            var driver = new Driver
            {
                Name = requestDto.Name,
                LastName = requestDto.LastName,
                PhoneNumber = requestDto.PhoneNumber,
                Dni = requestDto.Dni,
                Email = requestDto.Email,
                Password = requestDto.Password,
                Cars = new List<Car>(),
                Travels = new List<Travel>()
            };

            int driverId = _driverRepository.Add(driver);

            var car = new Car
            {
                Brand = requestDto.Car.Brand,
                Model = requestDto.Car.Model,
                Kilometers = requestDto.Car.Kilometers,
                LicensePlate = requestDto.Car.LicensePlate,
                Capacity = requestDto.Car.Capacity,
            };

            _carRepository.Add(car);

            driver.Cars.Add(car);

            _driverRepository.Update(driver);

            return driverId;
        }

        // READ
        public IEnumerable<DriverDto> GetAllDrivers()
        {
            var driverList = _driverRepository.GetAllDrivers();
            return DriverDto.CreateList(driverList);
        }

        public DriverDto? GetDriverById(int id)
        {
            var driver = _driverRepository.GetDriverById(id);

            if (driver == null)
            {
                return null;
            }

            return DriverDto.CreateDriver(driver);
        }

        // UPDATE
        public bool Update(int id, DriverUpdateDto requestDto)
        {
            var driver = _driverRepository.GetDriverById(id);

            if (driver == null)
            {
                return false; 
            }

            driver.Name = requestDto.Name;
            driver.LastName = requestDto.LastName;
            driver.PhoneNumber = requestDto.PhoneNumber;
            driver.Dni = requestDto.Dni;
            driver.Email = requestDto.Email;
            driver.Password = requestDto.Password;

            return _driverRepository.Update(driver); 
        }

        // DELETE
        public bool Delete(int id)
        {
            var driver = _driverRepository.GetDriverById(id);

            if (driver == null)
            {
                return false;
            }
            return _driverRepository.Delete(driver);
        }

        public IEnumerable<TravelDto> GetTravelsByDriverId(int driverId)
        {
            var driver = _driverRepository.GetDriverById(driverId);

            if (driver == null || driver.Travels == null || !driver.Travels.Any())
            {
                return Enumerable.Empty<TravelDto>();
            }

            return TravelDto.CreateList(driver.Travels);
        }

    }
}
