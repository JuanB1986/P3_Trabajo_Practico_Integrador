using Application.Interfaces;
using Application.Models;
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

        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        // CREATE
        public int Add(TravelCreateDto requestDto)
        {
            var travel = new Travel
            {
                StartDirection = requestDto.StartDirection,
                EndDirection = requestDto.EndDirection,
                StartTime = requestDto.StartTime,
                Price = requestDto.Price,
                DriverId = requestDto.DriverId,
                Status = TravelStatus.Pending 
            };

            return _travelRepository.Add(travel);
        }

        // READ
        public List<Travel> GetAll()
        {
            return _travelRepository.GetAll();
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