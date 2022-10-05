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
            invoiceHDR.Id = invoiceDto.Id;
            invoiceHDR.Customer = invoiceDto.Customer;
            invoiceHDR.PaymentMethod = invoiceDto.PaymentMethod == PaymentMethods.Cash.ToString() ? true : false;
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
        public static InvoiceDto Convert(InvoiceHDR invoiceHDR)
        {
            if (invoiceHDR is null) return null;
            InvoiceDto InvoiceDto = new();
            List<ItemDto> itemDtos = new();
            InvoiceDto.Id = invoiceHDR.Id;
            InvoiceDto.Customer = invoiceHDR.Customer;
            InvoiceDto.PaymentMethod = invoiceHDR.PaymentMethod == true ? PaymentMethods.Cash.ToString() : PaymentMethods.Credit.ToString();
            InvoiceDto.InvoiceDate = invoiceHDR.InvoiceDate;
            InvoiceDto.Description = invoiceHDR.Description;
            itemDtos.AddRange(invoiceHDR.ItemsDTL!.Select(a => Convert(a)));
            InvoiceDto.ItemDtos =itemDtos;
            return InvoiceDto;
        }
        public static ItemDto Convert(ItemsDTL itemsDTL)
        {
            ItemDto itemDto = new ItemDto();
            itemDto.ItemName = itemsDTL.ItemName;
            itemDto.InvoiceId = itemsDTL.InvoiceHDRId;
            itemDto.Price = itemsDTL.Price;
            itemDto.Qty = itemsDTL.Qty;
            return itemDto;
        }
    }
}
