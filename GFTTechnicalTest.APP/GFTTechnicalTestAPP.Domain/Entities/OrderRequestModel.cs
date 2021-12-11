using System.ComponentModel;

namespace GFTTechnicalTestAPP.Domain.Entities
{
    public class OrderRequestModel
    {
        [DisplayName("Entrada")]
        public string OrderInput { get; set; }
        [DisplayName("Saída")]
        public string OrderOutput { get; set; }
    }
}
