using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand>
    {
        private readonly IFinancialDbContext _context;
        public UpdateTransferCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            var transfer = await _context.Transfers.Where(p => p.Id == request.TransferId).FirstOrDefaultAsync(cancellationToken);

            _context.Transfers.Attach(transfer);
            _context.Transfers.Update(transfer).Property("Name").IsModified = true;
            _context.Transfers.Update(transfer).Property("Amount").IsModified = true;
            _context.Transfers.Update(transfer).Property("TransferType").IsModified = true;
            _context.Transfers.Update(transfer).Property("TransferCategory").IsModified = true;
            _context.Transfers.Update(transfer).Property("Date").IsModified = true;
            _context.Transfers.Update(transfer).Property("Desription").IsModified = true;
            _context.Transfers.Update(transfer).Property("Account").IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
