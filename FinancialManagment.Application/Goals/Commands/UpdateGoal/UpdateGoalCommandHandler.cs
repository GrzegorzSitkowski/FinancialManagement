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
            var goal = await _context.Goals.Where(p => p.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            goal.Name = request.Name;
            goal.TargetAmount = request.TargetAmount;
            goal.SavedAmount = request.SavedAmount;
            goal.DesiredDate = request.DesireDate;
            goal.Note = request.Note;
            goal.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
