using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoalDetail
{
    public class GetGoalDetailQueryHandler : IRequestHandler<GetGoalDetailQuery, GoalDetailVm>
    {
        private readonly IFinancialDbContext _context;

        public GetGoalDetailQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }
        public async Task<GoalDetailVm> Handle(GetGoalDetailQuery request, CancellationToken cancellationToken)
        {
            var goal = await _context.Goals.Where(p => p.Id == request.GoalId).FirstOrDefaultAsync(cancellationToken);

            var goalVm = new GoalDetailVm()
            {
                Name = goal.Name,
                TargetAmount = goal.TargetAmount,
                SavedAmount = goal.SavedAmount,
                DesireDate = goal.DesiredDate,
                Note = goal.Note,
                GoalCategorires = goal.GoalCategory
            };

            return goalVm;
        }
    }
}
