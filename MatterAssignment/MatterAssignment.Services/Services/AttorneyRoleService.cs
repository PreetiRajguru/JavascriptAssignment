using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;

namespace MatterAssignment.Services.Services
{
    public class AttorneyRoleService : IAttorneyRole
    {
        private readonly MatterAssignmentDbContext _context;

        public AttorneyRoleService(MatterAssignmentDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AttorneyRoleDTO> GetAllAttorneyRoles()
        {
            List<AttorneyRoleDTO> attorneyRoles = _context.AttorneyRole
                .Select(ar => new AttorneyRoleDTO
                {
                    Id = ar.Id,
                    AttorneyId = ar.AttorneyId,
                    RoleMasterId = ar.RoleMasterId
                })
                .ToList();

            return attorneyRoles;
        }

        public AttorneyRoleDTO GetAttorneyRoleById(int id)
        {
            AttorneyRoleDTO? attorneyRole = _context.AttorneyRole
                .Where(ar => ar.Id == id)
                .Select(ar => new AttorneyRoleDTO
                {
                    Id = ar.Id,
                    AttorneyId = ar.AttorneyId,
                    RoleMasterId = ar.RoleMasterId
                })
                .FirstOrDefault();

            return attorneyRole;
        }

        public void CreateAttorneyRole(AttorneyRoleDTO attorneyRole)
        {
            AttorneyRole newAttorneyRole = new AttorneyRole
            {
                AttorneyId = attorneyRole.AttorneyId,
                RoleMasterId = attorneyRole.RoleMasterId
            };

            _context.AttorneyRole.Add(newAttorneyRole);
            _context.SaveChanges();
        }

        public void DeleteAttorneyRole(int id)
        {
            AttorneyRole attorneyRole = _context.AttorneyRole.Find(id);

            if (attorneyRole != null)
            {
                _context.AttorneyRole.Remove(attorneyRole);
                _context.SaveChanges();
            }
        }
    }

}
