using Domain.Dtos;
using Domain.Entites;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class InvoiceMapping
    {
        public static InvoiceHDR Convert(InvoiceDto invoiceDto)
        {
            InvoiceHDR invoiceHDR = new InvoiceHDR();
            invoiceHDR.Customer = invoiceDto.Customer;
            invoiceHDR.PaymentMethod = invoiceDto.PaymentMethod==PaymentMethods.Cash.ToString()?true:false;
            invoiceHDR.InvoiceDate = invoiceDto.InvoiceDate;
            invoiceHDR.Description = invoiceDto.Description;
            return invoiceHDR;
        }
        public static ItemsDTL Convert(ItemDto itemDto)
        {
            ItemsDTL itemsDTL = new ItemsDTL();
            itemsDTL.ItemName = itemDto.ItemName;
            itemsDTL.InvoiceHDRId = itemDto.InvoiceId;
            itemsDTL.Price = itemDto.Price;
            itemsDTL.Qty = itemDto.Qty;
            return itemsDTL;
        }
        public static List<ItemsDTL> Convert(List<ItemDto> itemDtos)
        {
            List<ItemsDTL> itemsDTL = new List<ItemsDTL>();
            itemsDTL.AddRange(itemDtos.Select(a => Convert(a)));
            return itemsDTL; 
        }
    }
}
