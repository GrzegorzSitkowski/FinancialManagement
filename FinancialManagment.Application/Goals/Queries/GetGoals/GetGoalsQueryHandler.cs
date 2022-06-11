using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public GetGoalsQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }
        public async Task<GoalsVm> Handle(GetGoalsQuery request, CancellationToken cancellationToken)
        {
            var goals = await _context.Goals.AsNoTracking().ProjectTo<GoalsDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new GoalsVm() { Goals = goals };
        }
    }
}
