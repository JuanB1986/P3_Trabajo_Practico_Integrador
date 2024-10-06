using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Domain.Entities;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly TravelRepository _travelRepository;

        public TravelController(TravelRepository travelRepository) //Constructor: inicia travelRepository
        {
            _travelRepository = travelRepository;
        }   


        [HttpPost]
        public IActionResult AddTravels([FromBody] TravelCreateRequestDTO travelDTO)
        {
            Travel travel = new Travel()
            {
                TavelId = travelDTO.TavelId,
                StarDirection = travelDTO.StarDirection,
                EndDirection = travelDTO.EndDirection,
                StartTime = travelDTO.StartTime,
                price = travelDTO.price,
                Driver = travelDTO.Driver
            };

            return Ok(_travelRepository.Add(travel));
        }

        [HttpGet]
        public IActionResult GetTravels()
        {
            var travels = _travelRepository.GetAll();
            return Ok(_travelRepository.GetAll());
        }


    }
}
