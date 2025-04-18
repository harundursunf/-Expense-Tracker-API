using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    // User.cs
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Guid RoleId { get; set; }
        public Roles Role { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }


}
