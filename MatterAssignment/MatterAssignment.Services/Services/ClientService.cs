using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;

namespace MatterAssignment.Services.Services
{

    public class ClientService : IClient
    {
        private readonly MatterAssignmentDbContext _dbContext;

        public ClientService(MatterAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return _dbContext.Clients.Select(c => new ClientDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                Address = c.Address
            });
        }


        public ClientDTO GetById(int id)
        {
            Client client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                return new ClientDTO
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    PhoneNumber = client.PhoneNumber,
                    Email = client.Email,
                    Address = client.Address
                };
            }
            return null;
        }

        public ClientDTO Create(ClientDTO client)
        {
            Client newClient = new Client
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Address
            };
            _dbContext.Clients.Add(newClient);
            _dbContext.SaveChanges();
            client.Id = newClient.Id;
            return client;
        }

        public bool Delete(int id)
        {
            Client client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
