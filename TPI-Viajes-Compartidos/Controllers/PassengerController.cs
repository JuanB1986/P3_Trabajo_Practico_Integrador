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
        private readonly PassengerRepository _passengerRepository;

        public PassengerController(PassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        [HttpPost]
        public IActionResult AddPassenger([FromBody] PassengerCreateRequestDto requestdto)
        {
            Passenger passenger = new Passenger()
            {
                Name = requestdto.Name,
                LastName = requestdto.LastName,
                PhoneNumber = requestdto.PhoneNumber,
                Dni = requestdto.Dni,
                Email = requestdto.Email,
                Password = requestdto.Password,
    };

            return Ok(_passengerRepository.Add(passenger));
        }
    }
}
