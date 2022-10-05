using Application.Interfaces.Repositories;
using Bases.Application;
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
    public class InvoiceHDRRepository:BaseRepostiory<InvoiceHDR,int,InvoiceDbContext>,IInvoiceHDRRepository
    {
        public InvoiceHDRRepository(InvoiceDbContext dbContext) : base(dbContext)
        {

        }

        public InvoiceHDR GetInvoiceHDRs()
        {
            var Invoice = _dbContext.InvoiceHDRs.Include(a => a.ItemsDTL).OrderByDescending(a=>a.Id).FirstOrDefault(a=>!a.Is_Deleted);
            return Invoice!;
        }
    }
}
