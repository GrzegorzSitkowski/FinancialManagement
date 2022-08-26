using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IFinancialDbContext _context;

        public UpdateAccountCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (account == null)
                return Unit.Value;

            account.Id = request.Id;
            account.Name = request.Name;
            account.Amount = request.Amount;
            //_context.Accounts.Update(account).Property("AccountType").IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
