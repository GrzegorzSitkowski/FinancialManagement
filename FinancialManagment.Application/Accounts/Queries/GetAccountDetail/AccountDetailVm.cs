using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class AccountDetailVm : IMapFrom<Account>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Amount { get; set; }
        public ICollection<TransfersAccount> Transfers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountDetailVm>();
        }
    }
}
