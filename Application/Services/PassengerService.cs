using Application.Interfaces;
using Application.Models;
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

        public List<Passenger> Get()
        {
            return _passengerRepository.GetAllPassenger();
        }
        
        public int Add(PassengerCreateRequestDto requestdto)
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
            return _passengerRepository.AddPassenger(passenger);
        }

        public bool Delete(int id)
        {
            return _passengerRepository.DeletePassenger(id);
        }
    }
}
