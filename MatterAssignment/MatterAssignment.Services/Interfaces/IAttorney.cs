﻿using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Interfaces
{
    public interface IAttorney
    {
        IEnumerable<AttorneyDTO> GetAllAttorneys();
        AttorneyDTO GetAttorneyById(int id);
        void CreateAttorney(AttorneyDTO attorney);
        void DeleteAttorney(int id);
    }

}
