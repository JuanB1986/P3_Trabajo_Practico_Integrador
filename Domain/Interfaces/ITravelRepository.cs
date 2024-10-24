﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITravelRepository : IBaseRepository<Travel>
    {
        IEnumerable<Travel> GetAllTravels();
        Travel? GetTravelById(int id);
    }
}