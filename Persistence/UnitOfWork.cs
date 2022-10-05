using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InvoiceDbContext _dbContext;
        public IInvoiceHDRRepository InvoiceHDRRepository { get; }
        public IItemDTLRepository ItemDTLRepository { get; set; }
        public UnitOfWork(InvoiceDbContext  dbContext, IInvoiceHDRRepository invoiceHDRRepository, IItemDTLRepository itemDTLRepository)
        {
            _dbContext = dbContext;
            InvoiceHDRRepository = invoiceHDRRepository;
            ItemDTLRepository = itemDTLRepository;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
