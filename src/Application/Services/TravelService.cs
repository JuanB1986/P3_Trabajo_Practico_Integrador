using Application.Interfaces;
using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IDriverRepository _driverRepository;

        public TravelService(ITravelRepository travelRepository, IDriverRepository driverRepository)
        {
            _travelRepository = travelRepository;
            _driverRepository = driverRepository;
        }

        // CREATE
        public int Add(TravelCreateRequest requestDto)
        {
            var driver = _driverRepository.GetDriverById(requestDto.DriverId);

            if (driver == null)
            {
                return 0;
            }
            var car = driver.Cars.FirstOrDefault(car => car.IsAvailable);

            if (car == null) 
            {
                return 0;
            }

            var availableSeats = car.Capacity;

            var travel = new Travel
            {
                StartDirection = requestDto.StartDirection,
                EndDirection = requestDto.EndDirection,
                StartTime = requestDto.StartTime,
                Price = requestDto.Price,
                Driver = driver,
                Status = TravelStatus.Pending,
            };

            return _travelRepository.Add(travel);
        }

        // READ
        public IEnumerable<TravelDto> GetAllTravels()
        {
            var travelList = _travelRepository.GetAllTravels();
            return TravelDto.CreateList(travelList);
        }

        public TravelDto? GetTravelById(int id)
        {
            var travel = _travelRepository.GetTravelById(id);

            if (travel == null)
            {
                return null;
            }

            return TravelDto.CreateTravel(travel);
        }

        // UPDATE
        public bool Update(int id, TravelUpdateDto requestDto)
        {
            var travel = _travelRepository.GetTravelById(id);

            if (travel == null)
            {
                return false;
            }

            travel.StartDirection = requestDto.StartDirection;
            travel.EndDirection = requestDto.EndDirection;
            travel.StartTime = requestDto.StartTime;
            travel.Price = requestDto.Price;

            return _travelRepository.Update(travel);
        }

        // DELETE
        public bool Delete(int id)
        {
            var travel = _travelRepository.GetTravelById(id);

            if (travel == null)
            {
                return false;
            }
            return _travelRepository.Delete(travel);
        }
    }
}