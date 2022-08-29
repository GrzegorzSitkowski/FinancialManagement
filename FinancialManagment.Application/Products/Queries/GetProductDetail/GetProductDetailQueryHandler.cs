using AutoMapper;
using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IFinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IFinancialDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
