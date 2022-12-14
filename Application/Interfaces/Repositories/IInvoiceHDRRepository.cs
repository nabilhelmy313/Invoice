using Bases.Application;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IInvoiceHDRRepository:IBaseRepository<InvoiceHDR,int>
    {
        public InvoiceHDR GetInvoiceHDRs();
    }
}
