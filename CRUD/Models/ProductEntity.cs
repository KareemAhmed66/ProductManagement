
using CRUD.Models.Base;

namespace CRUD.Models
{
    public class ProductEntity: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; } // Foreign Key

        public virtual CategoryEntity Category { get; set; } // Navigation Property
    }
}