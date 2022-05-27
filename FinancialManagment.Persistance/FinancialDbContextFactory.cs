using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Persistance
{
    public class FinancialDbContextFactory : DesignTimeDbContextFactoryBase<FinancialDbContext>
    {
        protected override FinancialDbContext CreateNewInstance(DbContextOptions<FinancialDbContext> options)
        {
            return new FinancialDbContext(options);
        }
    }
}
