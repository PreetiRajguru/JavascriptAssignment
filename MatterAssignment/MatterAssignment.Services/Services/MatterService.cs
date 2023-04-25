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

        public IEnumerable<MatterDTO> GetAllMatters()
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

        public MatterDTO GetMatterById(int id)
        {
            var matter = _context.Matters.Find(id);
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

        public MatterDTO CreateMatter(MatterDTO matterDto)
        {
            var matter = new Matter
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

        public void DeleteMatter(int id)
        {
            var matter = _context.Matters.Find(id);
            if (matter != null)
            {
                _context.Matters.Remove(matter);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MatterDTO> GetMattersByClientId(int clientId)
        {
            var matters = _context.Matters
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

       
    }

}
