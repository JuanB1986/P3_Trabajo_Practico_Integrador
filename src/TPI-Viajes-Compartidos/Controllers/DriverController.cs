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
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        #region CREATE
        [HttpPost]
        public IActionResult CreateDriver([FromBody] DriverCreateRequest requestDto)
        {
            var driver = _driverService.Add(requestDto);
            return Ok(driver);
        }
        #endregion

        #region READ
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
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        [Authorize(Roles = "Driver")]
        public IActionResult Update(int id, [FromBody] DriverUpdateDto requestDto)
        {
            var isUpdated = _driverService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Driver with ID {id} not found." });
            }

            return Ok(new { Message = "Driver updated successfully." });
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Driver")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _driverService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Driver with ID {id} not found." });
            }

            return Ok(new { Message = "Driver deleted successfully." });
        }
        #endregion

        [HttpGet("{id}/travels")]
        public IActionResult GetTravelsByDriverId(int id)
        {
            var travels = _driverService.GetTravelsByDriverId(id);

            return Ok(travels);
        }

    }
}
