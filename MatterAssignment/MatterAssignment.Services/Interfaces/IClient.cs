using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IClient
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        ClientDTO Create(ClientDTO client);
        bool Delete(int id);
    }
}
