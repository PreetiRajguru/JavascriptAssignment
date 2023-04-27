using MatterAssignment.Services.DTO;

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
