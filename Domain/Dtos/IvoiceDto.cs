using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        [Required(ErrorMessage = "Please Select Invoice Date")]
        public string PaymentMethod { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please add Customer Name")]
        public string Customer { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<ItemDto>? ItemDtos { get; set; }
    }
}
