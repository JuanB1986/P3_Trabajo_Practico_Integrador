using Application.Interfaces;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Driver")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // CREATE
        [HttpPost]
        public IActionResult CreateCar([FromBody] CarCreateRequest requestDto)
        {
            var car = _carService.Add(requestDto);
            return Ok(car);
        }

        // READ
        [HttpGet]
        public IActionResult GetCars()
        {
            var car = _carService.GetAllCars();
            return Ok(car);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById([FromRoute] int id)
        {
            var car = _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound(new { Message = $"Car with ID {id} not found." });
            }

            return Ok(car);
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CarUpdateDto requestDto)
        {
            var isUpdated = _carService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Car with ID {id} not found." });
            }

            return Ok(new { Message = "Car updated successfully." });
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _carService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Car with ID {id} not found." });
            }

            return Ok(new { Message = "Car deleted successfully." });
        }
    }
    
}
