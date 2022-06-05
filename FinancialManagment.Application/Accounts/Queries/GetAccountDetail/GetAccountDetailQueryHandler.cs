using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQueryHandler : IRequestHandler<GetAccountDetailQuery, AccountDetailVm>
    {
        private readonly IFinancialDbContext _context;
        public GetAccountDetailQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<AccountDetailVm> Handle(GetAccountDetailQuery request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.Where(p => p.Id == request.AmountId).FirstOrDefaultAsync(cancellationToken);

            var accountVm = new AccountDetailVm()
            {
                Name = account.Name,
                AccountType = account.AccountType,
                Amount = account.Amount,
                Transfers = account.Transfers
            };

            return accountVm;
        }
    }
}
