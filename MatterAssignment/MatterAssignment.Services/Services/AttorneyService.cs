using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;

namespace MatterAssignment.Services.Services
{
    public class AttorneyService : IAttorney
    {
        private readonly MatterAssignmentDbContext _context;

        public AttorneyService(MatterAssignmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AttorneyDTO> GetAll()
        {
            IEnumerable<AttorneyDTO> attorneys = _context.Attorneys
                .Select(a => new AttorneyDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Rate = a.Rate,
                    JurisdictionId = a.JurisdictionId
                })
                .ToList();

            return attorneys;
        }

        public AttorneyDTO GetById(int id)
        {
            AttorneyDTO attorney = _context.Attorneys
                .Where(a => a.Id == id)
                .Select(a => new AttorneyDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Rate = a.Rate,
                    JurisdictionId = a.JurisdictionId
                })
                .FirstOrDefault();

            return attorney;
        }

        public void Create(AttorneyDTO attorney)
        {
            Attorney newAttorney = new Attorney
            {
                Name = attorney.Name,
                Rate = attorney.Rate,
                JurisdictionId = attorney.JurisdictionId
            };

            _context.Attorneys.Add(newAttorney);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Attorney attorney = _context.Attorneys.Find(id);

            if (attorney != null)
            {
                _context.Attorneys.Remove(attorney);
                _context.SaveChanges();
            }
        }
    }

}
