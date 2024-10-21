using Application.Interfaces;
using Application.Models;
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
        public int Add(DriverCreateDto requestDto)
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
                Travel = new List<Travel>()
            };

            int driverId = _driverRepository.Add(driver); 

            var car = new Car
            {
                Brand = requestDto.Car.Brand,
                Model = requestDto.Car.Model,
                Kilometers = requestDto.Car.Kilometers,
                LicensePlate = requestDto.Car.LicensePlate,
                Capacity = requestDto.Car.Capacity,
                Driver = driver
            };

            _carRepository.Add(car);

            driver.Cars.Add(car);

            _driverRepository.Update(driver);

            return driverId;
        }

        // READ
        public List<Driver> GetAll()
        {
            return _driverRepository.GetAll();
        }

        public Driver GetById(int Id)
        {
            return _driverRepository.GetById(Id);
        }

        public Driver? GetDriverWithCars(int Id)
        {
            return _driverRepository.GetDriverWithCars(Id);
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
