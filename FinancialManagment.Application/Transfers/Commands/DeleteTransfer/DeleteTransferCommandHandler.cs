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

            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
