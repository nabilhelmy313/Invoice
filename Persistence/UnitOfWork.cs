using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InvoiceDbContext _dbContext;

        public UnitOfWork(InvoiceDbContext  dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
