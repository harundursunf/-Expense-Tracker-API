using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RolesManager : IRolesService
    {
        private readonly IRolesDal _rolesDal;

        public RolesManager(IRolesDal rolesDal)
        {
            _rolesDal = rolesDal;
        }

        public void Add(RolesDto rolesDto)
        {
            var role = new Roles
            {
                Id = Guid.NewGuid(),
                RoleName = rolesDto.RoleName,
                CreatedAt = DateTime.UtcNow
            };

            _rolesDal.Add(role);
        }

        public void Delete(RolesDto rolesDto)
        {
            var role = _rolesDal.GetById(rolesDto.Id);
            if (role != null)
            {
                _rolesDal.Delete(role);
            }
        }

        public List<Roles> GetAll()
        {
            return _rolesDal.GetAll();
        }

        public Roles GetById(Guid id)
        {
            return _rolesDal.GetById(id);
        }

        public void Update(RolesDto rolesDto)
        {
            var role = _rolesDal.GetById(rolesDto.Id);
            if (role != null)
            {
                role.RoleName = rolesDto.RoleName;
                role.UpdatedAt = DateTime.UtcNow;
                _rolesDal.Update(role);
            }
        }
    }
}
