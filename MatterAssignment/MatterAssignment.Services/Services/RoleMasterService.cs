using MatterAssignment.Data.Context;
using MatterAssignment.Data.Models;
using MatterAssignment.Services.DTO;
using MatterAssignment.Services.Interfaces;

namespace MatterAssignment.Services.Services
{
    public class RoleMasterService : IRoleMaster
    {
        private readonly MatterAssignmentDbContext _dbContext;

        public RoleMasterService(MatterAssignmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoleMasterDTO> GetAll()
        {
            return _dbContext.RoleMaster.Select(r => new RoleMasterDTO
            {
                Id = r.Id,
                RoleName = r.RoleName
            });
        }

        public RoleMasterDTO GetById(int id)
        {
            var role = _dbContext.RoleMaster.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                return new RoleMasterDTO
                {
                    Id = role.Id,
                    RoleName = role.RoleName
                };
            }
            return null;
        }

        public RoleMasterDTO Create(RoleMasterDTO role)
        {
            var newRole = new RoleMaster
            {
                RoleName = role.RoleName
            };
            _dbContext.RoleMaster.Add(newRole);
            _dbContext.SaveChanges();
            role.Id = newRole.Id;
            return role;
        }

        public bool Delete(int id)
        {
            var role = _dbContext.RoleMaster.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                _dbContext.RoleMaster.Remove(role);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
