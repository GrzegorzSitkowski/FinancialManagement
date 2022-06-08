using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoals
{
    public class GetGoalsQueryHandler : IRequestHandler<GetGoalsQuery, GoalsVm>
    {
        private readonly IFinancialDbContext _context;

        public GetGoalsQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }
        public async Task<GoalsVm> Handle(GetGoalsQuery request, CancellationToken cancellationToken)
        {
            var goals = await _context.Goals.AsNoTracking().ProjectTo<GoalsDto>().ToListAsync();

            return new GoalsVm() { Goals = goals };
        }
    }
}
