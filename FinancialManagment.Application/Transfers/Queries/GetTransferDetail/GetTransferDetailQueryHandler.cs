using AutoMapper;
using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetTransferDetail
{
    public class GetTransferDetailQueryHandler : IRequestHandler<GetTransferDetailQuery, TransferDetailVm>
    {
        private readonly IFinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetTransferDetailQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }

        public async Task<TransferDetailVm> Handle(GetTransferDetailQuery request, CancellationToken cancellationToken)
        {
            var transfer = await _context.Transfers.Where(p => p.Id == request.TransferId).FirstOrDefaultAsync(cancellationToken);
            transfer.TransferType = await _context.TransferTypes.Where(p => p.Id == transfer.TypeId).FirstOrDefaultAsync(cancellationToken);
            transfer.TransferCategory = await _context.TransferCategories.Where(p => p.Id == transfer.CategoryId).FirstOrDefaultAsync(cancellationToken);

            var transferVm = _mapper.Map<TransferDetailVm>(transfer);

            return transferVm;
        }
    }
}
