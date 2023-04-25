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

        public IEnumerable<AttorneyDTO> GetAllAttorneys()
        {
            var attorneys = _context.Attorneys
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

        public AttorneyDTO GetAttorneyById(int id)
        {
            var attorney = _context.Attorneys
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

        public void CreateAttorney(AttorneyDTO attorney)
        {
            var newAttorney = new Attorney
            {
                Name = attorney.Name,
                Rate = attorney.Rate,
                JurisdictionId = attorney.JurisdictionId
            };

            _context.Attorneys.Add(newAttorney);
            _context.SaveChanges();
        }

        public void DeleteAttorney(int id)
        {
            var attorney = _context.Attorneys.Find(id);

            if (attorney != null)
            {
                _context.Attorneys.Remove(attorney);
                _context.SaveChanges();
            }
        }
    }

}
