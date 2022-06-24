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
            if (transfer == null)
                return Unit.Value;


            transfer.Id = request.TransferId;
            transfer.Name = request.Name;
            transfer.TypeId = request.TypeId;
            transfer.CategoryId = request.CategoryId;
            transfer.Date = request.Date;
            transfer.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
