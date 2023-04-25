using MatterAssignment.Services.DTO;

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
