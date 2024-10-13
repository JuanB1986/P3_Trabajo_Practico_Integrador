using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // CREATE
        public int Add(CarCreateDto requestDto)
        {
            Car car = new Car()
            {
                Brand = requestDto.Brand,
                Model = requestDto.Model,
                Kilometers = requestDto.Kilometers,
                LicensePlate = requestDto.LicensePlate,
                Capacity = requestDto.Capacity
            };

            return _carRepository.Add(car);
        }

        // READ
        public List<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car GetById(int Id)
        {
            return _carRepository.GetById(Id);
        }

        // UPDATE
        public bool Update(int Id, CarUpdateDto requestDto)
        {
            var car = _carRepository.GetById(Id);

            car.Brand = requestDto.Brand;
            car.Model = requestDto.Model;
            car.Kilometers = requestDto.Kilometers;
            car.LicensePlate = requestDto.LicensePlate;
            car.Capacity = requestDto.Capacity;

            return _carRepository.Update(car);
        }
        
        // DELETE
        public bool Delete(int Id)
        {
            var car = _carRepository.GetById(Id);

            return _carRepository.Delete(car);
        }
    }
}
