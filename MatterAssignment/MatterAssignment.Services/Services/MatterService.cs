using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatterAssignment.Services.Services
{
    public class MatterService : IMatter
    {
        private readonly MatterAssignmentDbContext _context;

        public MatterService(MatterAssignmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MatterDTO> GetAll()
        {
            return _context.Matters.Select(m => new MatterDTO
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                ClientId = m.ClientId,
                BillingAttorneyId = m.BillingAttorneyId,
                ResponsibleAttorneyId = m.ResponsibleAttorneyId,
                JurisdictionId = m.JurisdictionId
            });
        }

        public MatterDTO GetById(int id)
        {
            Matter matter = _context.Matters.Find(id);
            if (matter == null)
            {
                return null;
            }

            return new MatterDTO
            {
                Id = matter.Id,
                Title = matter.Title,
                Description = matter.Description,
                ClientId = matter.ClientId,
                BillingAttorneyId = matter.BillingAttorneyId,
                ResponsibleAttorneyId = matter.ResponsibleAttorneyId,
                JurisdictionId = matter.JurisdictionId
            };
        }

        public MatterDTO Create(MatterDTO matterDto)
        {
            Matter matter = new Matter
            {
                Title = matterDto.Title,
                Description = matterDto.Description,
                ClientId = matterDto.ClientId,
                BillingAttorneyId = matterDto.BillingAttorneyId,
                ResponsibleAttorneyId = matterDto.ResponsibleAttorneyId,
                JurisdictionId = matterDto.JurisdictionId
            };

            _context.Matters.Add(matter);
            _context.SaveChanges();

            matterDto.Id = matter.Id;
            return matterDto;
        }

        public void Delete(int id)
        {
            Matter matter = _context.Matters.Find(id);
            if (matter != null)
            {
                _context.Matters.Remove(matter);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MatterDTO> GetMattersByClientId(int clientId)
        {
            IEnumerable<MatterDTO> matters = _context.Matters
                .Where(m => m.ClientId == clientId)
                .Select(m => new MatterDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    ClientId = m.ClientId,
                    BillingAttorneyId = m.BillingAttorneyId,
                    ResponsibleAttorneyId = m.ResponsibleAttorneyId,
                    JurisdictionId = m.JurisdictionId
                })
                .ToList();

            return matters;
        }

        public Dictionary<int, List<MatterDTO>> GetMattersForClient()
        {
            List<Matter> matters = _context.Matters.ToList();

            Dictionary<int, List<MatterDTO>> groupedMatters = matters.GroupBy(m => m.ClientId)
                                        .ToDictionary(g => g.Key,
                                                      g => g.Select(m => new MatterDTO
                                                      {
                                                          Title = m.Title,
                                                          Description = m.Description,
                                                          BillingAttorneyId = m.BillingAttorneyId,
                                                          ResponsibleAttorneyId = m.ResponsibleAttorneyId,
                                                          JurisdictionId = m.JurisdictionId
                                                      }).ToList());

            return groupedMatters;
        }
    }
}
