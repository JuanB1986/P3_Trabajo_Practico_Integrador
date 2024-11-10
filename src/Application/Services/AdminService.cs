using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IDriverRepository _driverRepository;

        // Constructor actualizado con repositorios de Driver y Passenger
        public AdminService(IAdminRepository adminRepository, IPassengerRepository passengerRepository, IDriverRepository driverRepository)
        {
            _adminRepository = adminRepository;
            _passengerRepository = passengerRepository;
            _driverRepository = driverRepository;
        }

        // CREATE
        public int Add(AdminCreateDto requestdto)
        {
            Admin admin = new Admin()
            {
                Name = requestdto.Name,
                LastName = requestdto.LastName,
                PhoneNumber = requestdto.PhoneNumber,
                Dni = requestdto.Dni,
                Email = requestdto.Email,
                Password = requestdto.Password,
            };
            return _adminRepository.Add(admin);
        }

        // READ
        public IEnumerable<AdminDto> GetAllAdmins()
        {
            var adminList = _adminRepository.GetAllAdmins();
            return AdminDto.CreateList(adminList);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            // Obtener todos los pasajeros y conductores
            var passengers = _passengerRepository.GetAllPassengers();
            var drivers = _driverRepository.GetAllDrivers();

            // Combinar las listas y devolverlas
            var users = passengers
                .Select(p => new UserDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    LastName = p.LastName,
                    Dni = p.Dni,
                    PhoneNumber = p.PhoneNumber,
                    Role = "Passenger",
                    Email = p.Email
                })
                .Concat(drivers.Select(d => new UserDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    LastName = d.LastName,
                    Dni = d.Dni,
                    PhoneNumber = d.PhoneNumber,
                    Role = "Driver",
                    Email = d.Email
                }))
                .ToList();

            return users;
        }

        public AdminDto? GetAdminById(int id)
        {
            var admin = _adminRepository.GetAdminById(id);

            if (admin == null)
            {
                return null;
            }

            return AdminDto.CreateAdmin(admin);
        }

        // UPDATE
        public bool Update(int id, AdminUpdateDto requestDto)
        {
            var admin = _adminRepository.GetAdminById(id);

            if (admin == null)
            {
                return false;
            }

            admin.Name = requestDto.Name;
            admin.LastName = requestDto.LastName;
            admin.PhoneNumber = requestDto.PhoneNumber;
            admin.Dni = requestDto.Dni;
            admin.Email = requestDto.Email;
            admin.Password = requestDto.Password;

            return _adminRepository.Update(admin);
        }

        // DELETE
        public bool Delete(int id)
        {
            var admin = _adminRepository.GetAdminById(id);

            if (admin == null)
            {
                return false;
            }
            return _adminRepository.Delete(admin);
        }
    }
}
