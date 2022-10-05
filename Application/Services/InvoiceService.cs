using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mapping;
using Bases.Domain;
using Domain.Dtos;

namespace Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddNewInovice(InvoiceDto invoiceDto)
        {
            try
            {
                var invoiceMap = InvoiceMapping.Convert(invoiceDto);
                _unitOfWork.InvoiceHDRRepository.Create(invoiceMap);
                int res = await _unitOfWork.CommitAsync();
                var item = InvoiceMapping.Convert(invoiceDto.ItemDtos!);
                foreach (var i in item)
                {
                    i.InvoiceHDRId = invoiceMap.Id;
                }
                _unitOfWork.ItemDTLRepository.CreateRange(item);
                res = await _unitOfWork.CommitAsync();
                return new ServiceResponse<bool>
                {
                    Data = res != 0,
                    Message = "Sucess",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteInvoice(int invoiceId)
        {
            try
            {
                _unitOfWork.InvoiceHDRRepository.SoftDelete(invoiceId);

            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
