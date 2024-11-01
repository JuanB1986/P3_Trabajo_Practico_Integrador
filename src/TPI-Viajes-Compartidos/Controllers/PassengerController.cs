using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Passenger")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        
        [HttpPost]
        public IActionResult CreatePassenger([FromBody] PassengerCreateDto requestDto)
        {
            var passenger = _passengerService.Add(requestDto);
            return Ok(passenger);
        }
        

        
        [HttpGet]
        public IActionResult GetPassengers()
        {
            var passenger = _passengerService.GetAllPassengers();
            return Ok(passenger);
        }

        [HttpGet("{id}")]
        public IActionResult GetPassengerById([FromRoute] int id)
        {
            var passenger = _passengerService.GetPassengerById(id);

            if (passenger == null)
            {
                return NotFound(new { Message = $"Passenger with ID {id} not found." });
            }

            return Ok(passenger);
        }
        

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PassengerUpdateDto requestDto)
        {
            var isUpdated = _passengerService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Passenger with ID {id} not found." });
            }

            return Ok(new { Message = "Passenger updated successfully." });
        }
        

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _passengerService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Passenger with ID {id} not found." });
            }

            return Ok(new { Message = "Passenger deleted successfully." });
        }       
    }
}
