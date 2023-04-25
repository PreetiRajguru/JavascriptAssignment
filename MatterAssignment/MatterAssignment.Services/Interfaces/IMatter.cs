using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IMatter
    {
        IEnumerable<MatterDTO> GetAllMatters();
        MatterDTO GetMatterById(int id);
        MatterDTO CreateMatter(MatterDTO matter);
        void DeleteMatter(int id);
        IEnumerable<MatterDTO> GetMattersByClientId(int clientId);



    }


}
