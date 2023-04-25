using MatterAssignment.Services.DTO;

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
