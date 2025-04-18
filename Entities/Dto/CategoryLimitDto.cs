using System;

namespace Entities.Dto
{
    public class CategoryLimitDto
    {
        public Guid CategoryId { get; set; }
        public decimal LimitAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
