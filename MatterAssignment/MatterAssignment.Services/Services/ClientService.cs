using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatterAssignment.Services.Services
{

    public class ClientService : IClient
    {
        private MatterAssignmentDbContext _context;
        public ClientService(MatterAssignmentDbContext newContext)
        {
            _context = newContext;
        }

        public async Task<List<ClientDTO>> GetAllClients()
        {           
            var clients = await _context.Clients.AsNoTracking().ToListAsync();

            return clients.Select(c => new ClientDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                Address = c.Address
            }).ToList();

        }


        public ClientDTO GetById(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);

            return client != null ? new ClientDTO
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Address
            } : null;
        }


        public ClientDTO Create(ClientDTO clientDto)
        {
            if (clientDto == null)
            {
                throw new ArgumentNullException(nameof(clientDto));
            }

            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                PhoneNumber = clientDto.PhoneNumber,
                Email = clientDto.Email,
                Address = clientDto.Address
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return clientDto;
        }
    }
}
