using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Interfaces
{
    public interface IRoleMaster
    {
        IEnumerable<RoleMasterDTO> GetAll();
        RoleMasterDTO GetById(int id);
        RoleMasterDTO Create(RoleMasterDTO role);
        bool Delete(int id);
    }
}
