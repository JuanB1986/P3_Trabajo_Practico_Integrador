using Application.Models;
using Application.Models.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITravelService
    {
        int Add(TravelCreateRequest requestdto);
        IEnumerable<TravelDto> GetAllTravels();
        TravelDto? GetTravelById(int id);
        bool Update(int id, TravelUpdateDto requestDto);
        bool Delete(int id);
    }
}