using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand>
    {
        private readonly IFinancialDbContext _context;
        public DeleteTransferCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _context.Transfers.Where(p => p.Id == request.TransferId).FirstOrDefaultAsync(cancellationToken);
            var account = _context.Accounts.FirstOrDefault(p => p.Id == transfer.AccountId);

            if (transfer.TypeId == 2 || transfer.TypeId == 3)
            {
                account.Amount += transfer.Amount;
            }
            else if (transfer.TypeId == 1)
            {
                account.Amount -= transfer.Amount;
            }

            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
