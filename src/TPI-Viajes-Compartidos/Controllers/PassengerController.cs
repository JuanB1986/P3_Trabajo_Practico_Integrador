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
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        #region CREATE
        [HttpPost]
        public IActionResult CreatePassenger([FromBody] PassengerCreateDto requestDto)
        {
            var passenger = _passengerService.Add(requestDto);
            return Ok(passenger);
        }
        #endregion

        #region READ
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
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        [Authorize(Roles = "Passenger")]
        public IActionResult Update(int id, [FromBody] PassengerUpdateDto requestDto)
        {
            var isUpdated = _passengerService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Passenger with ID {id} not found." });
            }

            return Ok(new { Message = "Passenger updated successfully." });
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Passenger")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _passengerService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Passenger with ID {id} not found." });
            }

            return Ok(new { Message = "Passenger deleted successfully." });
        }
        #endregion

        #region NEW RESERVE
        [HttpPost("{passengerId}/reserve/{travelId}")]
        [Authorize(Roles = "Passenger")]
        public IActionResult AddReservation(int passengerId, int travelId)
        {
            var isReserved = _passengerService.AddReservation(passengerId, travelId);

            if (!isReserved)
            {
                return NotFound(new { Message = $"Unable to reserve travel." });
            }

            return Ok(new { Message = "Travel reserved successfully." });
        }
        #endregion

        #region REMOVE RESERVE
        [HttpPost("{passengerId}/cancel-reservation/{travelId}")]
        [Authorize(Roles = "Passenger")]
        public IActionResult CancelReservation(int passengerId, int travelId)
        {
            var isCanceled = _passengerService.CancelReservation(passengerId, travelId);

            if (!isCanceled)
            {
                return NotFound(new { Message = $"Unable to cancel reservation." });
            }

            return Ok(new { Message = "Reservation canceled successfully." });
        }
        #endregion
    }
}
