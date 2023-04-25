using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IJurisdictionMaster
    {
        IEnumerable<JurisdictionMasterDTO> GetAll();
        JurisdictionMasterDTO GetById(int id);
        void Create(JurisdictionMasterDTO jurisdictionMaster);
        void Delete(int id);
    }

}
