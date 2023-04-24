using MatterAssignment.Data.Context;
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
    }
}
