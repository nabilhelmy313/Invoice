using Bases.Application;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IItemDTLRepository:IBaseRepository<ItemsDTL,int>
    {
        Task<bool> DeleteItemsInInvoice(int invoiceId);
    }
}
