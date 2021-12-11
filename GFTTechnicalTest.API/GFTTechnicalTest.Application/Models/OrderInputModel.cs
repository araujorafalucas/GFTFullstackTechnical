using System.ComponentModel.DataAnnotations;

namespace GFTTechnicalTest.Application.Models
{
    public class OrderInputModel
    {
        [Required]
        public string OrderInput { get; set; }
    }
}
