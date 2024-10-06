using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository;

        public CarController(CarRepository carRepository) //Constructor: inicia carRepository
        {
            _carRepository = carRepository;
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] CarCreateRequestDTO carRequestdto)
        {
            Car car = new Car()
            {
                CarId = carRequestdto.CarId,
                Brand = carRequestdto.Brand,
                Model = carRequestdto.Model,
                Kilometers = carRequestdto.Kilometers,
                LicensePlate = carRequestdto.LicensePlate,
                IsAvailable = carRequestdto.IsAvailable,
                Capacity= carRequestdto.Capacity

            };

            return Ok(_carRepository.Add(car));
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var car = _carRepository.GetAll();
            return Ok(car);

        }

    }
}
