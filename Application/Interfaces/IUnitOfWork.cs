using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IInvoiceHDRRepository  InvoiceHDRRepository{ get; }
        public IItemDTLRepository  ItemDTLRepository { get; set; }
        Task<int> CommitAsync();
    }
}
