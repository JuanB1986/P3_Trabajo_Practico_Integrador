using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
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

        [HttpGet("{Id}")]
        public IActionResult GetCarById(int Id)
        {
            try
            {
                var car = _carService.GetById(Id);
                return Ok(car);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // UPDATE
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] CarUpdateDto requestDto)
        {
            try
            {
                var result = _carService.Update(Id, requestDto);
                return Ok(new { Message = "Car updated successfully." });
            }
            catch (InvalidOperationException exception)
            {
                return NotFound(new { Message = exception.Message });
            }
        }

        // DELETE
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var result = _carService.Delete(Id);
                return Ok(new { Message = "Car deleted successfully." });
            }
            catch (InvalidOperationException exception)
            {
                return NotFound(new { Message = exception.Message });
            }
        }
    }
}
