using Bases.Domain;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class InvoiceHDR:BaseEntity<int>
    {
        public DateTime InvoiceDate { get; set; }
        /// <summary>
        /// if true so ites cash if false ites credit
        /// </summary>
        public bool PaymentMethod { get; set; }
        [MaxLength(150,ErrorMessage ="Max Length is 150 Characters")]
        public string Customer { get; set; }=string.Empty;
        [MaxLength(500, ErrorMessage = "Max Length is 500 Characters")]
        public string? Description { get; set; }
        public virtual ICollection<ItemsDTL>? ItemsDTL { get; set; } 
    }
}
