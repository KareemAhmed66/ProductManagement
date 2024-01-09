using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
