using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Interfaces
{
    public interface IAttorney
    {
        IEnumerable<AttorneyDTO> GetAll();
        AttorneyDTO GetById(int id);
        void Create(AttorneyDTO attorney);
        void Delete(int id);
    }

}
