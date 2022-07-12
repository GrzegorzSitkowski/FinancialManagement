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
                TypeId = request.TypeId,
                TransferType = request.TransferType,
                CategoryId = request.CategoryId,
                TransferCategory = request.TransferCategory,
                Date = request.Date,
                Description = request.Description,
                AccountId = request.AccountId,
                Account = request.Account
            };

            var account = _context.Accounts.FirstOrDefault(p => p.Id == transfer.AccountId);

            if(transfer.TypeId == 2 || transfer.TypeId ==3)
            {
                account.Amount -= transfer.Amount;
            }
            else if(transfer.TypeId == 1)
            {
                account.Amount += transfer.Amount;
            }
           
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync(cancellationToken);

            return transfer.Id;
        }
    }
}
