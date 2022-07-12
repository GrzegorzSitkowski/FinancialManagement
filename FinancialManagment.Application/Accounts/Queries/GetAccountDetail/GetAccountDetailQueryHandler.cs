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

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQueryHandler : IRequestHandler<GetAccountDetailQuery, AccountDetailVm>
    {
        private readonly IFinancialDbContext _context;
        private readonly IMapper _mapper;
        public GetAccountDetailQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }

        public async Task<AccountDetailVm> Handle(GetAccountDetailQuery request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.Where(p => p.Id == request.AccountId).FirstOrDefaultAsync(cancellationToken);
            account.Transfers = await _context.Transfers.Where(p => p.AccountId == request.AccountId && p.StatusId == 1).ToListAsync();

            var accountVm = _mapper.Map<AccountDetailVm>(account);

            return accountVm;
        }
    }
}
