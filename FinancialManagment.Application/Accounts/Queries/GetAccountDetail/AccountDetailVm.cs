using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class AccountDetailVm
    {
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
    }
}
