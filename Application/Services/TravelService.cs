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
                throw new InvalidOperationException($"No se encontró un conductor con ID {requestDto.DriverId}");
            }

            var travel = new Travel
            {
                StartDirection = requestDto.StartDirection,
                EndDirection = requestDto.EndDirection,
                StartTime = requestDto.StartTime,
                Price = requestDto.Price,
                Driver = driver,
                Status = TravelStatus.Pending
            };

            return _travelRepository.Add(travel);
        }

        // READ
        public IEnumerable<TravelDto> GetAllTravels()
        {
            var list = _travelRepository.GetAllTravels();
            return TravelDto.CreateList(list);
        }

        public Travel GetById(int Id)
        {
            return _travelRepository.GetById(Id);
        }

        // UPDATE
        public bool Update(int Id, TravelUpdateDto requestDto)
        {
            var travel = _travelRepository.GetById(Id);

            travel.StartDirection = requestDto.StartDirection;
            travel.EndDirection = requestDto.EndDirection;
            travel.StartTime = requestDto.StartTime;
            travel.Price = requestDto.Price;

            return _travelRepository.Update(travel);
        }

        // DELETE
        public bool Delete(int Id)
        {
            var travel = _travelRepository.GetById(Id);

            return _travelRepository.Delete(travel);
        }
    }

}