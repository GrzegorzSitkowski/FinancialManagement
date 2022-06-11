using FinancialManagment.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IFinancialDbContext _context;
        public UpdateProductCommandHandler(IFinancialDbContext financialDbContext)
        {
            _context = financialDbContext;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.ShoppingLists.Where(p => p.Id == request.ProductId).FirstOrDefaultAsync(cancellationToken);

            _context.ShoppingLists.Attach(product);
            _context.ShoppingLists.Update(product).Property("Product").IsModified = true;
            _context.ShoppingLists.Update(product).Property("Price").IsModified = true;
            _context.ShoppingLists.Update(product).Property("Done").IsModified = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
