using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetPassengers()
        {
            var passanger = _passengerService.Get();
            return Ok(passanger);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PassengerCreateRequestDto requestDto) 
        {
            return Ok(_passengerService.Add(requestDto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _passengerService.Delete(id);

            if (result)
            {
                return Ok(new { Message = "Passenger deleted successfully." });
            }

            return NotFound(new { Message = "Passenger not found." });
        }

    }
}
