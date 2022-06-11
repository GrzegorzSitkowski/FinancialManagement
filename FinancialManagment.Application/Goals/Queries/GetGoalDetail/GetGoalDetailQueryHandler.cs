using AutoMapper;
using FinancialManagment.Application.Common.Interfaces;
using FinancialManagment.Domain.Entities;
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
        private readonly IMapper _mapper;

        public GetGoalDetailQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }
        public async Task<GoalDetailVm> Handle(GetGoalDetailQuery request, CancellationToken cancellationToken)
        {
            var goal = await _context.Goals.Where(p => p.Id == request.GoalId).FirstOrDefaultAsync(cancellationToken);

            var goalVm = _mapper.Map<GoalDetailVm>(goal);

            return goalVm;
        }
    }
}
