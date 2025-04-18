using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    // CategoryLimit.cs
    public class CategoryLimit : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal LimitAmount { get; set; } // Örn: 1000 TL
        public DateTime StartDate { get; set; }  // Limitin geçerli olduğu tarih aralığı
        public DateTime EndDate { get; set; }
    }


}
