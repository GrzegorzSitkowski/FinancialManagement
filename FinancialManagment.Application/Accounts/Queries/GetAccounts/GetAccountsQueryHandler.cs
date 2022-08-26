using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public GetAccountsQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }
        public async Task<AccountsVm> Handle(GetAccountsQuery getAccountsQuery, CancellationToken none)
        {
            var accounts = await _context.Accounts.AsNoTracking().Where(p => p.StatusId == 1).ProjectTo<AccountsDto>(_mapper.ConfigurationProvider).ToListAsync();
            return new AccountsVm() { Accounts = accounts };
        }
    }
}
