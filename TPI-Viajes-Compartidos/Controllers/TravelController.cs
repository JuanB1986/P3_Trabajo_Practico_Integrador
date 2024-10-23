using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Domain.Entities;
using Application.Interfaces;
using Application.Services;
using Application.Models.Request;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        // CREATE
        [HttpPost]
        public IActionResult CreateTravel([FromBody] TravelCreateRequest requestDto)
        {
            var travel = _travelService.Add(requestDto);
            return Ok(travel);
        }

        // READ
        [HttpGet]
        public IActionResult GetTravels()
        {
            var travels = _travelService.GetAllTravels();
            return Ok(travels);
        }

        [HttpGet("{Id}")]
        public IActionResult GetTravelById(int Id)
        {
            try
            {
                var travel = _travelService.GetById(Id);
                return Ok(travel);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // UPDATE
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] TravelUpdateDto requestDto)
        {
            try
            {
                var result = _travelService.Update(Id, requestDto);
                return Ok(new { Message = "Travel updated successfully." });
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
                var result = _travelService.Delete(Id);
                return Ok(new { Message = "Travel deleted successfully." });
            }
            catch (InvalidOperationException exception)
            {
                return NotFound(new { Message = exception.Message });
            }
        }
    }
}

