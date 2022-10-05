using Bases.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class ItemsDTL:BaseEntity<int>
    {
        public int InvoiceHDRId { get; set; }
        public string ItemName { get; set; }=string.Empty;  
        public int Qty { get; set; }
        public decimal Price{ get; set; }
        public virtual InvoiceHDR InvoiceHDR  { get; set; }
    }
}
