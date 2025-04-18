using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRolesService
    {
        void Add(RolesDto RolesDto);
        void Update(RolesDto RolesDto);
        void Delete(RolesDto RolesDto);
        Roles GetById(Guid id);
        List<Roles> GetAll();
    }
}
