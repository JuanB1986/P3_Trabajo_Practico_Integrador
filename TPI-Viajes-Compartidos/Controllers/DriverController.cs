using Application.Models;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverRepository _driverRepository;

        public DriverController (DriverRepository driverRepository)
        {
            _driverRepository = driverRepository;  
        }


        [HttpPost]
        public IActionResult AddDriver([FromBody] DriverCreateRequestDto driverCreateRequestDTO)
        {
            Driver driver = new Driver()
            {
                Name = driverCreateRequestDTO.Name,
                LastName = driverCreateRequestDTO.LastName,
                PhoneNumber = driverCreateRequestDTO.PhoneNumber,
                Dni = driverCreateRequestDTO.Dni,
                Email = driverCreateRequestDTO.Email,
                Password = driverCreateRequestDTO.Password,
                Cars = driverCreateRequestDTO.Cars,
                Travels = driverCreateRequestDTO.Travels
            };

            return Ok(_driverRepository.Add(driver));
        }

        [HttpGet]
        public IActionResult GetDrivers() 
        {
            var driver = _driverRepository.GetAll();
            return Ok(driver);

        }
    }
}
