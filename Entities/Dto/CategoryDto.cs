namespace Entities.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; } // Güncelleme ve silme için lazım
        public string CategoryName { get; set; }
        public Guid UserId { get; set; } // Category entity'sinde var
    }
}
