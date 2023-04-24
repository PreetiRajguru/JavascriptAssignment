using MatterAssignment.Services.DTO;

namespace MatterAssignment.Services.Interfaces
{
    public interface IClient
    {
        Task<List<ClientDTO>> GetAllClients();

        ClientDTO GetById(int id);

        ClientDTO Create(ClientDTO clientDto);

    }
}
