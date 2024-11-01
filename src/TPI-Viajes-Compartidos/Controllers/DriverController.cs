using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        
        [HttpPost]        
        public IActionResult CreateDriver([FromBody] DriverCreateRequest requestDto)
        {
            var driver = _driverService.Add(requestDto);
            return Ok(driver);
        }
        

        
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var drivers = _driverService.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetDriverById([FromRoute] int id)
        {
            var driver = _driverService.GetDriverById(id);

            if (driver == null)
            {
                return NotFound(new { Message = $"Driver with ID {id} not found." });
            }

            return Ok(driver);
        }
        

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DriverUpdateDto requestDto)
        {
            var isUpdated = _driverService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Driver with ID {id} not found." });
            }

            return Ok(new { Message = "Driver updated successfully." });
        }
        

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _driverService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Driver with ID {id} not found." });
            }

            return Ok(new { Message = "Driver deleted successfully." });
        }
        
    }
}
