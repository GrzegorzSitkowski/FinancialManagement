using FinancialManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType() { Id = 1, Name = "General" },
                new AccountType() { Id = 2, Name = "Cash" },
                new AccountType() { Id = 3, Name = "Current account" },
                new AccountType() { Id = 4, Name = "Credit card" },
                new AccountType() { Id = 5, Name = "Saving account" },
                new AccountType() { Id = 6, Name = "Bonus" },
                new AccountType() { Id = 7, Name = "Insurance" },
                new AccountType() { Id = 8, Name = "Investment" },
                new AccountType() { Id = 9, Name = "Loan" },
                new AccountType() { Id = 10, Name = "Mortgage" },
                new AccountType() { Id = 11, Name = "Account with overdraft" }
                );

            modelBuilder.Entity<TransferType>().HasData(
                new TransferType() { Id = 1, Name = "Income" },
                new TransferType() { Id = 2, Name = "Expense" },
                new TransferType() { Id = 3, Name = "Transfer" }
                );

            modelBuilder.Entity<TransferCategory>().HasData(
                new TransferCategory() { Id = 1, Name = "Food & Drinks" },
                new TransferCategory() { Id = 2, Name = "Shopping" },
                new TransferCategory() { Id = 3, Name = "Housing" },
                new TransferCategory() { Id = 4, Name = "Transportation" },
                new TransferCategory() { Id = 5, Name = "Vehicle" },
                new TransferCategory() { Id = 6, Name = "Life & Entertainment" },
                new TransferCategory() { Id = 7, Name = "Communicationn, PC" },
                new TransferCategory() { Id = 8, Name = "Financial expenses" },
                new TransferCategory() { Id = 9, Name = "Investments" },
                new TransferCategory() { Id = 10, Name = "Income" },
                new TransferCategory() { Id = 11, Name = "Others" }
                );

            modelBuilder.Entity<GoalCategory>().HasData(
                new GoalCategory() { Id = 1, Name = "New vehicle" },
                new GoalCategory() { Id = 2, Name = "New home" },
                new GoalCategory() { Id = 3, Name = "Holiday trip" },
                new GoalCategory() { Id = 4, Name = "Education" },
                new GoalCategory() { Id = 5, Name = "Emergency fund" },
                new GoalCategory() { Id = 6, Name = "Health care" },
                new GoalCategory() { Id = 7, Name = "Party" },
                new GoalCategory() { Id = 8, Name = "Kids spoiling" },
                new GoalCategory() { Id = 9, Name = "Charity" }
                );
        }
    }
}
