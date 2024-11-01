using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;
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
        private readonly ITravelRepository _travelRepository;
        public PassengerService(IPassengerRepository passengerRepository, ITravelRepository travelRepository)
        {
            _passengerRepository = passengerRepository;
            _travelRepository = travelRepository;
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
            var passengerList = _passengerRepository.GetAllPassengers();
            return PassengerDto.CreateList(passengerList);
        }

        public PassengerDto? GetPassengerById(int id)
        {
            var passenger = _passengerRepository.GetPassengerById(id);

            if (passenger == null)
            {
                return null;
            }

            return PassengerDto.CreatePassenger(passenger);
        }

        // UPDATE
        public bool Update(int id, PassengerUpdateDto requestDto)
        {
            var passenger = _passengerRepository.GetPassengerById(id);

            if (passenger == null)
            {
                return false;
            }

            passenger.Name = requestDto.Name;
            passenger.LastName = requestDto.LastName;
            passenger.PhoneNumber = requestDto.PhoneNumber;
            passenger.Dni = requestDto.Dni;
            passenger.Email = requestDto.Email;
            passenger.Password = requestDto.Password;

            return _passengerRepository.Update(passenger);
        }

        // DELETE
        public bool Delete(int id)
        {
            var passenger = _passengerRepository.GetPassengerById(id);

            if (passenger == null)
            {
                return false;
            }
            return _passengerRepository.Delete(passenger);
        }
    }
}
