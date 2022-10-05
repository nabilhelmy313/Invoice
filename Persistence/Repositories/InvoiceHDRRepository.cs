using Application.Interfaces.Repositories;
using Bases.Application;
using Bases.Infrastructure;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InvoiceHDRRepository:BaseRepostiory<InvoiceHDR,int,InvoiceDbContext>,IInvoiceHDRRepository
    {
        public InvoiceHDRRepository(InvoiceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
