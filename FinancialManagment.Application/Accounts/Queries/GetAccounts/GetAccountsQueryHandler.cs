using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccounts
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, AccountsVm>
    {
        private readonly IFinancialDbContext _context;

        public GetAccountsQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }
        public async Task<AccountsVm> Handle(GetAccountsQuery getAccountsQuery, CancellationToken none)
        {
            var accounts = await _context.Accounts.AsNoTracking().ProjectTo<AccountsDto>().ToListAsync();

            return new AccountsVm() { Accounts = accounts };
        }
    }
}
