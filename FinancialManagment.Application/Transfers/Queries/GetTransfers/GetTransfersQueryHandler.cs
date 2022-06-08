using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Queries.GetTransfers
{
    public class GetTransfersQueryHandler : IRequestHandler<GetTransfersQuery, TransfersVm>
    {
        private readonly IFinancialDbContext _context;

        public GetTransfersQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<TransfersVm> Handle(GetTransfersQuery request, CancellationToken cancellationToken)
        {
            var transfers = await _context.Transfers.AsNoTracking().ProjectTo<TransfersDto>().ToListAsync();

            return new TransfersVm() { Transfers = transfers };
        }
    }
}
