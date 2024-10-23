using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        // CREATE
        public int Add(PassengerCreateDto requestdto)
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
            return _passengerRepository.Add(passenger);
        }

        // READ
        public IEnumerable<PassengerDto> GetAllPassengers()
        {
            var list = _passengerRepository.GetAllPassengers();
            return PassengerDto.CreateList(list);
        }

        public PassengerDto GetPassengerById(int Id)
        {
            var passenger = _passengerRepository.GetPassengerById(Id);
            if (passenger == null)
            {
                throw new KeyNotFoundException($"No passenger was found with ID {Id}");
            }

            return PassengerDto.CreatePassenger(passenger);
        }

        // UPDATE
        public bool Update(int Id, PassengerUpdateDto requestDto)
        {
            var passenger = _passengerRepository.GetById(Id);

            passenger.Name = requestDto.Name;
            passenger.LastName = requestDto.LastName;
            passenger.PhoneNumber = requestDto.PhoneNumber;
            passenger.Dni = requestDto.Dni;
            passenger.Email = requestDto.Email;
            passenger.Password = requestDto.Password;

            return _passengerRepository.Update(passenger);
        }

        // DELETE
        public bool Delete(int Id)
        {
            var passenger = _passengerRepository.GetById(Id);

            return _passengerRepository.Delete(passenger);
        }
    }
}
