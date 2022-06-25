using FinancialManagment.Application.Common.Interfaces;
using FinancialManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.CreateGoal
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, int>
    {
        private readonly IFinancialDbContext _context;
        public CreateGoalCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<int> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            Goal goal = new()
            {
                Name = request.Name,
                TargetAmount = request.TargetAmount,
                SavedAmount = request.SavedAmount,
                DesiredDate = request.DesiredDate,
                Note = request.Note,
                CategoryId = request.CategoryId,
                GoalCategory = request.GoalCategory
            };

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync(cancellationToken);

            return goal.Id;
        }
    }
}
