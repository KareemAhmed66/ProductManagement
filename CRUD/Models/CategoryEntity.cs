
using CRUD.Models.Base;

namespace CRUD.Models
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<ProductEntity> Products { get; set; }
    }
}
