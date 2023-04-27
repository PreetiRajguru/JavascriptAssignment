using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IAttorney
    {
        List<AttorneyWithIdDTO> GetAll();
        AttorneyDTO GetById(int id);
        void Create(AttorneyDTO attorney);
        void Delete(int id);
    }

}
