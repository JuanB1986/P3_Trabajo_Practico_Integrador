using Application.Models;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPassengerService
    {
        int Add(PassengerCreateDto requestdto);
        IEnumerable<PassengerDto> GetAllPassengers();
        PassengerDto? GetPassengerById(int id);
        bool Update(int id, PassengerUpdateDto requestDto);
        bool Delete(int id);
        bool AddReservation(int passengerId, int travelId);
        bool CancelReservation(int passengerId, int travelId);
        IEnumerable<TravelForResponse> GetReservedTravels(int passengerId);
    }
}
