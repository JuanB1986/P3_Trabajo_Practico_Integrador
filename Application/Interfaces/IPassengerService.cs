﻿using Application.Models;
using Application.Models.Request;
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
        PassengerDto? GetPassengerById(int Id);
        bool Update(int Id, PassengerUpdateDto requestDto);
        bool Delete(int Id);
    }
}
