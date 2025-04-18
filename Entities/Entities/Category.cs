using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    // Category.cs
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public Guid UserId { get; set; }

        // Her kategori için birden fazla limit olabilir (aylık, haftalık vs.)
        public ICollection<CategoryLimit> Limits { get; set; } = new List<CategoryLimit>();
    }



}
