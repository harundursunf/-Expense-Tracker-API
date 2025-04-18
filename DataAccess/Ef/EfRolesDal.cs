using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Repositories;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Ef
{
    public class EfRolesDal : GenericRepository<Roles>, IRolesDal
    {
        public EfRolesDal(ExpenseDbContext context) : base(context)
        {
        }
    }
}
