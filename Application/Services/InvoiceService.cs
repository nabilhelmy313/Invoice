using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Mapping;
using Bases.Domain;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;

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
                int res = 0;
                var x=_unitOfWork.InvoiceHDRRepository.FindByID(invoiceDto.Id);
                if (x is null)
                {
                    invoiceMap.Id = 0;
                    _unitOfWork.InvoiceHDRRepository.Create(invoiceMap);
                     res = await _unitOfWork.CommitAsync();
                }
                var item = InvoiceMapping.Convert(invoiceDto.ItemDtos!.Where(a=>a.InvoiceId==0).ToList());
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

        public async Task<ServiceResponse<InvoiceDto>> GetInvoice()
        {
            try
            {
                var invoiceHDRs = _unitOfWork.InvoiceHDRRepository.GetInvoiceHDRs();
                var map=InvoiceMapping.Convert(invoiceHDRs!);
                return new ServiceResponse<InvoiceDto>
                {
                    Data = map,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<InvoiceDto>
                {
                    Data = new InvoiceDto
                    {
                        InvoiceDate = DateTime.Now,
                        ItemDtos = new List<ItemDto>(),
                    },
                    Message = ex.Message,
                    Success = false
                };
            }
        }
        public async Task<ServiceResponse<bool>> DeleteInvoice(int invoiceId)
        {
            try
            {
                var succes = await _unitOfWork.ItemDTLRepository.DeleteItemsInInvoice(invoiceId);
                _unitOfWork.InvoiceHDRRepository.SoftDelete(invoiceId);
                var res =await _unitOfWork.CommitAsync();
                return new ServiceResponse<bool>
                {
                    Data = succes,
                    Message = "deleted sucessfully",
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


    }
}
