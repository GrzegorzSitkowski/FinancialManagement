using FinancialManagment.Application.Common.Interfaces;
using FinancialManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, int>
    {
        private readonly IFinancialDbContext _context;
        public CreateTransferCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<int> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            Transfer transfer = new()
            {
                Name = request.Name,
                Amount = request.Amount,
                TransferType = request.TransferType,
                TransferCategory = request.TransferCategory,
                Date = request.Date,
                Description = request.Description,
                Account = request.Account
            };

            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync(cancellationToken);

            return transfer.Id;
        }
    }
}
