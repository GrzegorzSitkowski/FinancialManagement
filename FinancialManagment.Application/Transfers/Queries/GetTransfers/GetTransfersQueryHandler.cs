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

namespace FinancialManagment.Application.Transfers.Queries.GetTransfers
{
    public class GetTransfersQueryHandler : IRequestHandler<GetTransfersQuery, TransfersDto>
    {
        private readonly IFinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetTransfersQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }

        public async Task<TransfersDto> Handle(GetTransfersQuery request, CancellationToken cancellationToken)
        {
            var transfers = await _context.Transfers.AsNoTracking().Where(p => p.StatusId == 1).ProjectTo<TransfersDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new TransfersDto();
        }
    }
}
