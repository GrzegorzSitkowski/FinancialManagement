using FinancialManagment.Domain.Entities;
using FinancialManagment.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static void InitilizedDbForTests(FinancialDbContext context)
        {
            var account = new Account()
            {
                Id = 9,
                StatusId = 1,
                Amount = 3000,
                TypeId = 1,
                Name = "Oszczednosciowe"
            };
            context.Accounts.Add(account);

            var goal = new Goal()
            {
                Id = 1,
                StatusId = 1,
                CategoryId = 1,
                Name = "Auto",
                Note = "Audi",
                SavedAmount = 1000,
                TargetAmount = 20000
            };
            context.Goals.Add(goal);

            var product = new ShoppingList()
            {
                Id = 1,
                Done = true,
                Price = 20,
                StatusId = 1
            };
            context.ShoppingLists.Add(product);

            var transfer = new Transfer()
            {
                Id = 1,
                StatusId = 1,
                AccountId = 1,
                Amount = 50,
                CategoryId = 2,
                Description = "Home",
                Name = "Lidl",
                TypeId = 2
            };
            context.Transfers.Add(transfer);

            context.SaveChanges();
        }
    }
}
