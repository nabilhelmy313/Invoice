using System.ComponentModel.DataAnnotations;
namespace Domain.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        [Required(ErrorMessage = "Please add ItemName ")]
        public string ItemName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please add Quantity")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Please add Price ")]
        public decimal Price { get; set; }
    }
}
