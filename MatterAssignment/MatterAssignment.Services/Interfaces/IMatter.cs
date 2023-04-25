using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IMatter
    {
        IEnumerable<MatterDTO> GetAll();
        MatterDTO GetById(int id);
        MatterDTO Create(MatterDTO matter);
        void Delete(int id);
        IEnumerable<MatterDTO> GetMattersForClient(int clientId);

        /*  Dictionary<int, List<MatterDTO>> GetMattersForClient();*/


        IEnumerable<ClientMatterDTO> GetMattersByClients();



    }
}
