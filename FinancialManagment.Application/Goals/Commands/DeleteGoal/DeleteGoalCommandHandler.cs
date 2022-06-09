using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.DeleteGoal
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
    {
        private readonly IFinancialDbContext _context;
        public DeleteGoalCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _context.Goals.Where(p => p.Id == request.GoalId).FirstOrDefaultAsync(cancellationToken);

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
