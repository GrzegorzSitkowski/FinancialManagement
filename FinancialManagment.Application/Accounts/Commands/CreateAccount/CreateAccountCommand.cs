using FinancialManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int TypeId { get; set; }
        public AccountType accountType { get; set; }
    }
}
