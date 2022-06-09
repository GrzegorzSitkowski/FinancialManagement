using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
    {
        private readonly IFinancialDbContext _context;
        public UpdateGoalCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _context.Goals.Where(p => p.Id == request.GoalId).FirstOrDefaultAsync(cancellationToken);

            _context.Goals.Attach(goal);
            _context.Goals.Update(goal).Property("Name").IsModified = true;
            _context.Goals.Update(goal).Property("TargetAmount").IsModified = true;
            _context.Goals.Update(goal).Property("SavedAmount").IsModified = true;
            _context.Goals.Update(goal).Property("DesiredDate").IsModified = true;
            _context.Goals.Update(goal).Property("Note").IsModified = true;
            _context.Goals.Update(goal).Property("goalCategory").IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
