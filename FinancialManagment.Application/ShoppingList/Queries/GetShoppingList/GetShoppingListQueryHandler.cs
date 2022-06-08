using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetShoppingList
{
    public class GetShoppingListQueryHandler : IRequestHandler<GetShoppingListQuery, ShoppingListVm>
    {
        private readonly IFinancialDbContext _context;
        public GetShoppingListQueryHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }
        public async Task<ShoppingListVm> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = await _context.ShoppingLists.AsNoTracking().ProjectTo<ShoppingListDto>.ToListAsync();

            return new ShoppingListVm() { ShoppingList = shoppingList };
        }
    }
}
