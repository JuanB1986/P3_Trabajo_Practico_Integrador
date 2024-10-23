﻿using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Services;
using Domain.Entities;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        // CREATE
        [HttpPost]
        public IActionResult CreateDriver([FromBody] DriverCreateRequest requestDto)
        {
            var driver = _driverService.Add(requestDto);
            return Ok(driver);
        }

        // READ
        [HttpGet]
        public IActionResult GetDrivers()
        {
            var drivers = _driverService.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpGet("{Id}")]
        public IActionResult GetDriverById(int Id)
        {
            try
            {
                var driver = _driverService.GetDriverById(Id);
                return Ok(driver);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        // UPDATE
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, [FromBody] DriverUpdateDto requestDto)
        {
            try
            {
                var result = _driverService.Update(Id, requestDto);
                return Ok(new { Message = "Driver updated successfully." });
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
                var result = _driverService.Delete(Id);
                return Ok(new { Message = "Driver deleted successfully." });
            }
            catch (InvalidOperationException exception)
            {
                return NotFound(new { Message = exception.Message });
            }
        }
    }
}
