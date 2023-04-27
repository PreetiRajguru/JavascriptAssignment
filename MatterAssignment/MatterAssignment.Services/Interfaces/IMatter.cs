using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IMatter
    {
        IEnumerable<MatterDTO> GetAll();

        MatterDTO GetById(int id);

        MatterDTO Create(MatterDTO matter);

        void Delete(int id);

        List<MatterForClientDTO> GetMattersForClient(int clientId);

        IEnumerable<ClientMatterDTO> GetMattersByClients();
    }
}
