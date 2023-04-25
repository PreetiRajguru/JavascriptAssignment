using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Interfaces
{
    public interface IJurisdictionMaster
    {
        IEnumerable<JurisdictionMasterDTO> GetAllJurisdictionMasters();
        JurisdictionMasterDTO GetJurisdictionMasterById(int id);
        void CreateJurisdictionMaster(JurisdictionMasterDTO jurisdictionMaster);
        void DeleteJurisdictionMaster(int id);
    }

}
