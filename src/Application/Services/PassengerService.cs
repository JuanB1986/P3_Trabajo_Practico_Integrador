using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Application.Models.Response;
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

        public IEnumerable<TravelForResponse> GetReservedTravels(int passengerId)
        {
            var passenger = _passengerRepository.GetPassengerById(passengerId);

            if (passenger == null || !passenger.Reservations.Any())
            {
                return new List<TravelForResponse>();
            }

            var reservedTravels = TravelForResponse.CreateList(passenger.Reservations);
            return reservedTravels;
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

        // RESERVATION
        public bool AddReservation(int passengerId, int travelId)
        {
            var passenger = _passengerRepository.GetPassengerById(passengerId);
            var travel = _travelRepository.GetTravelById(travelId);

            // Verifica si el pasajero y el viaje existen, y si el viaje está en estado 'Pending'
            if (passenger == null || travel == null || travel.Status != TravelStatus.Pending)
            {
                return false;
            }

            // Obtiene el primer auto disponible del conductor.
            var availableCar = travel.Driver!.Cars.FirstOrDefault(c => c.IsAvailable);

            // Verifica si hay un auto disponible
            if (availableCar == null)
            {
                return false; 
            }

            int pasajeros = travel.Passengers.Count;
            int capacidad = availableCar.Capacity;

            // Verifica si el viaje está lleno
            if (pasajeros >= capacidad)
            {
                return false; 
            }

            // Agrega el viaje a las reservas del pasajero
            passenger.Reservations.Add(travel);

            // Verifica si el pasajero ya está asignado al viaje
            if (!travel.Passengers.Any(p => p.Id == passengerId))
            {
                travel.Passengers.Add(passenger);
            }

            _passengerRepository.Update(passenger);
            _travelRepository.Update(travel);

            return true;
        }

        // REMOVE RESERVATION
        public bool CancelReservation(int passengerId, int travelId)
        {
            var passenger = _passengerRepository.GetPassengerById(passengerId);
            var travel = _travelRepository.GetTravelById(travelId);

            // Verifica si el pasajero y el viaje existen, y si el viaje está en estado 'Pending'
            if (passenger == null || travel == null || travel.Status != TravelStatus.Pending)
            {
                return false;
            }
            // Verifica si el pasajero está en la lista de pasajeros del viaje
            var existingPassenger = travel.Passengers.FirstOrDefault(p => p.Id == passengerId);
            if (existingPassenger == null)
            {
                return false; 
            }

            passenger.Reservations.Remove(travel);
            travel.Passengers.Remove(existingPassenger);

            _passengerRepository.Update(passenger);
            _travelRepository.Update(travel);

            return true;
        }
    }
}
