using Application.Interfaces.Repositories;
using Bases.Infrastructure;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ItemDTLRepository:BaseRepostiory<ItemsDTL,int,InvoiceDbContext>,IItemDTLRepository
    {
        public ItemDTLRepository(InvoiceDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<bool> DeleteItemsInInvoice(int invoiceId)
        {
            var items=await _dbContext.ItemsDTLs.Where(a=>a.Id == invoiceId).ToListAsync();
            var ids = items.Select(a => a.Id).ToArray();
            SoftDelete(ids);
            return true;
        }
    }
}
