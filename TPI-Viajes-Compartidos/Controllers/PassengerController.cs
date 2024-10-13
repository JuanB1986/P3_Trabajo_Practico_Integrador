using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
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
            var passenger = _passengerService.GetAll();
            return Ok(passenger);
        }

        [HttpGet("{Id}")]
        public IActionResult GetPassengerById(int Id)
        {
            try
            {
                var passenger = _passengerService.GetById(Id);
                return Ok(passenger);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
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
