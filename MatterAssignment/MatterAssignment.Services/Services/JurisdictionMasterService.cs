using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;

namespace MatterAssignment.Services.Services
{
    public class JurisdictionMasterService : IJurisdictionMaster
    {
        private readonly MatterAssignmentDbContext _context;

        public JurisdictionMasterService(MatterAssignmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<JurisdictionMasterDTO> GetAll()
        {
            return _context.JurisdictionMaster
                .Select(j => new JurisdictionMasterDTO
                {
                    Id = j.Id,
                    JurisdictionName = j.JurisdictionName
                });
}

        public JurisdictionMasterDTO GetById(int id)
        {
            JurisdictionMasterDTO jurisdiction = _context.JurisdictionMaster
                .Where(j => j.Id == id)
                .Select(j => new JurisdictionMasterDTO
                {
                    Id = j.Id,
                    JurisdictionName = j.JurisdictionName
                })
                .FirstOrDefault();

            return jurisdiction;
        }

        public void Create(JurisdictionMasterDTO jurisdictionMaster)
        {
            JurisdictionMaster newJurisdiction = new JurisdictionMaster
            {
                JurisdictionName = jurisdictionMaster.JurisdictionName
            };

            _context.JurisdictionMaster.Add(newJurisdiction);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            JurisdictionMaster jurisdiction = _context.JurisdictionMaster.Find(id);

            if (jurisdiction != null)
            {
                _context.JurisdictionMaster.Remove(jurisdiction);
                _context.SaveChanges();
            }
        }
    }
}
