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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #region CREATE
        [HttpPost]
        public IActionResult CreateAdmin([FromBody] AdminCreateDto requestDto)
        {
            var admin = _adminService.Add(requestDto);
            return Ok(admin);
        }
        #endregion

        #region READ
        [HttpGet]
        public IActionResult GetAdmins()
        {
            var admin = _adminService.GetAllAdmins();
            return Ok(admin);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdminById([FromRoute] int id)
        {
            var admin = _adminService.GetAdminById(id);

            if (admin == null)
            {
                return NotFound(new { Message = $"Admin with ID {id} not found." });
            }

            return Ok(admin);
        }
        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AdminUpdateDto requestDto)
        {
            var isUpdated = _adminService.Update(id, requestDto);

            if (!isUpdated)
            {
                return NotFound(new { Message = $"Admin with ID {id} not found." });
            }

            return Ok(new { Message = "Admin updated successfully." });
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _adminService.Delete(id);

            if (!isDeleted)
            {
                return NotFound(new { Message = $"Admin with ID {id} not found." });
            }

            return Ok(new { Message = "Admin deleted successfully." });
        }
        #endregion

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _adminService.GetAllUsers();
            return Ok(users);
        }

    }
}
