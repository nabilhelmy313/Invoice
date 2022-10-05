using Bases.Domain;
using Domain.Dtos;
namespace Application.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task<ServiceResponse<bool>> AddNewInovice(InvoiceDto invoiceDto);
    }
}
