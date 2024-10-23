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
    [Authorize(Roles ="Passenger")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        // CREATE
        [HttpPost]
        public IActionResult CreatePassenger([FromBody] PassengerCreateDto requestDto)
        {
            var passenger = _passengerService.Add(requestDto);
            return Ok(passenger);
        }

        // READ
        [HttpGet]
        public IActionResult GetPassengers()
        {
            var passenger = _passengerService.GetAllPassengers();
            return Ok(passenger);
        }

        [HttpGet("{id}")]
        public IActionResult GetPassengerById([FromRoute] int Id)
        {
            var passenger = _passengerService.GetPassengerById(Id);
            return Ok(passenger);
        }



        // UPDATE
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] PassengerUpdateDto requestDto)
        {
            try
            {
                var result = _passengerService.Update(Id, requestDto);
                return Ok(new { Message = "Passenger updated successfully." });
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
                var result = _passengerService.Delete(Id);
                return Ok(new { Message = "Passenger deleted successfully." });
            }
            catch (InvalidOperationException exception)
            {
                return NotFound(new { Message = exception.Message });
            }
        }
    }
}
