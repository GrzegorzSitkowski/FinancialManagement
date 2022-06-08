using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetTransferDetail
{
    public class GetTransferDetailQueryHandler : IRequestHandler<GetTransferDetailQuery, TransferDetailVm>
    {
        private readonly IFinancialDbContext _context;

        public GetTransferDetailQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<TransferDetailVm> Handle(GetTransferDetailQuery request, CancellationToken cancellationToken)
        {
            var transfer = await _context.Transfers.Where(p => p.Id == request.TransferId).FirstOrDefaultAsync(cancellationToken);

            var transferVm = new TransferDetailVm()
            {
                Name = transfer.Name,
                Amount = transfer.Amount,
                TransferType = transfer.TransferType,
                TransferCategory = transfer.TransferCategory,
                Date = transfer.Date,
                Description = transfer.Description,
                Account = transfer.Account
            };

            return transferVm;
        }
    }
}
