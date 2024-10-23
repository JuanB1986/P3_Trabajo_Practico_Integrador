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
            var list = _driverRepository.GetAllDrivers();
            return list.Select(driver => DriverDto.CreateDriver(driver)).ToList();
        }

        public DriverDto? GetDriverById(int Id)
        {
            var driver = _driverRepository.GetDriverById(Id);
            if (driver == null)
            {
                throw new KeyNotFoundException($"No driver was found with ID {Id}");
            }
            return DriverDto.CreateDriver(driver);
        }

        // UPDATE
        public bool Update(int Id, DriverUpdateDto requestDto)
        {
            var driver = _driverRepository.GetById(Id);

            driver.Name = requestDto.Name;
            driver.LastName = requestDto.LastName;
            driver.PhoneNumber = requestDto.PhoneNumber;
            driver.Dni = requestDto.Dni;
            driver.Email = requestDto.Email;
            driver.Password = requestDto.Password;

            return _driverRepository.Update(driver);
        }

        // DELETE
        public bool Delete(int Id)
        {
            var driver = _driverRepository.GetById(Id);

            return _driverRepository.Delete(driver);
        }
    }
}
