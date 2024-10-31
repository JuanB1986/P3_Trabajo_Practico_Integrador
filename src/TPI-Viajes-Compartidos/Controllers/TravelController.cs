using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Domain.Entities;
using Application.Interfaces;
using Application.Services;
using Application.Models.Request;
using Microsoft.AspNetCore.Authorization;

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

        #region CREATE
        [HttpPost]
        [Authorize(Roles = "Driver")]
        public IActionResult CreateTravel([FromBody] TravelCreateRequest requestDto)
        {
            var travel = _travelService.Add(requestDto);

            if (travel == 0)
            {
                return NotFound(new { Message = $"Travel not found." });
            }
            return Ok(travel);
        }
        #endregion

        #region READ
        [HttpGet]
        public IActionResult GetTravels()
        {
            var travels = _travelService.GetAllTravels();
            return Ok(travels);
        }

        [HttpGet("{id}")]
        public IActionResult GetTravelById([FromRoute] int id)
        {
            var travel = _travelService.GetTravelById(id);

            if (travel == null)
            {
                return NotFound(new { Message = $"Travel with ID {id} not found." });
            }
            return Ok(travel);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        [Authorize(Roles = "Driver")]
        public IActionResult Update(int id, [FromBody] TravelUpdateDto requestDto)
        {
            var isUpdated = _travelService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Travel with ID {id} not found." });
            }

            return Ok(new { Message = "Travel updated successfully." });
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        [Authorize(Roles = "Driver")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _travelService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Travel with ID {id} not found." });
            }

            return Ok(new { Message = "Travel deleted successfully." });
        }
        #endregion
    }
}

