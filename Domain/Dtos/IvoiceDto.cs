using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string PaymentMethod { get; set; }=string.Empty;  
        public string Customer { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<ItemDto>? ItemDtos { get; set; }
    }
}
