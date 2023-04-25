using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Interfaces
{
    public interface IAttorneyRole
    {
        IEnumerable<AttorneyRoleDTO> GetAll();
        AttorneyRoleDTO GetById(int id);
        void Create(AttorneyRoleDTO attorneyRole);
        void Delete(int id);
    }
}
