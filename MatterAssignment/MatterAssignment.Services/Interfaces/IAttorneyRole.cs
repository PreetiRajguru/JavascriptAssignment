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
        IEnumerable<AttorneyRoleDTO> GetAllAttorneyRoles();
        AttorneyRoleDTO GetAttorneyRoleById(int id);
        void CreateAttorneyRole(AttorneyRoleDTO attorneyRole);
        void DeleteAttorneyRole(int id);
    }
}
