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
        public async Task<bool> DeleteItemsInInvoice()
        {
            _dbcontext
        }
    }
}
