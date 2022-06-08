using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccounts
{
    public class AccountsDto
    {
        public string Name { get; set; }
        public AccountType accountType { get; set; }
        public decimal Amount { get; set; }
    }
}
