using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.ShoppingList.Commands.CreateShoppingList
{
    public class CreateShoppingListHandler : IRequestHandler<CreateShoppingListCommand, int>
    {
        private readonly IFinancialDbContext _context;

        public CreateShoppingListHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<int> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            ShoppingList shoppingList = new()
            {
                Product = request.Product,
                Price = request.Price,
                Done = request.Done
            };

            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync(cancellationToken);

            return shoppingList.Id;
        }
    }
}
