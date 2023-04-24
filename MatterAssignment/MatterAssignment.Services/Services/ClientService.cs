using MatterAssignment.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterAssignment.Services.Services
{
    public interface IClient
    {
        List<ClientDTO> GetClients();
        ClientDTO GetClient(int id);
        int AddClient(ClientDTO client);
        /*int UpdateClient(int id, ClientDTO updatedClient);
        int DeleteClient(int id);*/
    }
    public class ClientService : IClient
    {
        public int AddClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO> GetClients()
        {
            throw new NotImplementedException();
        }
    }
}
