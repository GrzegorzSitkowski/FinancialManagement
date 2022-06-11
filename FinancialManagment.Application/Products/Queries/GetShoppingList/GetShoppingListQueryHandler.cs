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

namespace FinancialManagment.Application.Products.Queries.GetShoppingList
{
    public class GetShoppingListQueryHandler : IRequestHandler<GetShoppingListQuery, ShoppingListVm>
    {
        private readonly IFinancialDbContext _context;
        private readonly IMapper _mapper;
        public GetShoppingListQueryHandler(IFinancialDbContext financialDbContext, IMapper mapper)
        {
            _context = financialDbContext;
            _mapper = mapper;
        }
        public async Task<ShoppingListVm> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = await _context.ShoppingLists.AsNoTracking().ProjectTo<ShoppingListDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new ShoppingListVm() { Products = shoppingList };
        }
    }
}
