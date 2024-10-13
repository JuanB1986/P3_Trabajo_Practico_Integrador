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
            var car = new Car
            {
                Brand = requestDto.Car.Brand,
                Model = requestDto.Car.Model,
                Kilometers = requestDto.Car.Kilometers,
                LicensePlate = requestDto.Car.LicensePlate,
                Capacity = requestDto.Car.Capacity
            };

            var carId = _carRepository.Add(car);

            var driver = new Driver
            {
                Name = requestDto.Name,
                LastName = requestDto.LastName,
                PhoneNumber = requestDto.PhoneNumber,
                Dni = requestDto.Dni,
                Email = requestDto.Email,
                Password = requestDto.Password,
                CarsId = new List<int> { carId }
            };

            return _driverRepository.Add(driver);
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
