using FinancialManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Common.Interfaces
{
    public interface IFinancialDbContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<AccountType> AccountTypes { get; set; }
        DbSet<Goal> Goals { get; set; }
        DbSet<GoalCategory> GoalCategories { get; set; }
        DbSet<ShoppingList> ShoppingLists { get; set; }
        DbSet<Transfer> Transfers { get; set; }
        DbSet<TransferCategory> TransferCategories { get; set; }
        DbSet<TransferType> TransferTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
