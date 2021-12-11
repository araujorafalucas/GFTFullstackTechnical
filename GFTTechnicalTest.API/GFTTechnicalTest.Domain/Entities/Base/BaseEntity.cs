using System.ComponentModel.DataAnnotations;

namespace GFTTechnicalTest.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
